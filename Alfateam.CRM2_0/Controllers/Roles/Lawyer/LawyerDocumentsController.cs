using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Enums;
using Alfateam.CRM2_0.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer
{
    [DepartmentFilter]
    [AccessActionFilter(roles: UserRole.Lawyer)]
    public class LawyerDocumentsController : AbsController
    {
        public LawyerDocumentsController(ControllerParams @params) : base(@params)
        {
        }

		#region Документы

		[HttpGet, Route("GetDocuments")]
		public async Task<RequestResult> GetDocuments(int offset, int count = 20)
        {
            var documents = DB.Documents.Where(o => o.LawDepartmentId == DepartmentId && !o.IsDeleted)
			                            .Include(o => o.CreatedBy)
										.Skip(offset)
										.Take(count)
										.ToList();
			return RequestResult<IEnumerable<Document>>.AsSuccess(documents);
		}

		[HttpGet, Route("GetDocument")]
		public async Task<RequestResult> GetDocument(int id)
		{
			var document = DB.Documents.Include(o => o.CreatedBy)
									   .Include(o => o.Versions)
									   .Include(o => o.SignedDocument).ThenInclude(o => o.Version)
									   .Include(o => o.SignedDocument).ThenInclude(o => o.EDMProvider)
									   .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocument(document),
				() => RequestResult<Document>.AsSuccess(document)
			});
		}





		[HttpPost, Route("CreateDocument")]
		public async Task<RequestResult> CreateDocument(DocumentCreateModel model)
		{
			var authorizedUser = GetAuthorizedUser();
			return TryCreateModel(DB.Documents, model, async (item) =>
			{
				item.CreatedById = authorizedUser.Id;
				item.LawDepartmentId = (int)this.DepartmentId;
			});
		}

		[HttpPut, Route("UpdateDocument")]
		public async Task<RequestResult> UpdateDocument(DocumentEditModel model)
		{
			var document = DB.Documents.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocumentToEdit(document),
				() => TryUpdateModel(DB.Documents, document, model)
			});
		}

		[HttpDelete, Route("DeleteDocument")]
		public async Task<RequestResult> DeleteDocument(int id)
		{
			var document = DB.Documents.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocumentToEdit(document),
				() => DeleteModel(DB.Documents, document)
			});

		}


		#region Версии документа

		[HttpPost, Route("CreateDocumentVersion")]
		public async Task<RequestResult> CreateDocumentVersion(int documentId, DocumentVersionCreateModel model)
		{
			var document = DB.Documents.Include(o => o.Versions).FirstOrDefault(o => o.Id == documentId && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocumentToEdit(document),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var lastVersion = document.Versions.LastOrDefault(o => !o.IsDeleted);
					if(lastVersion != null && lastVersion.Status == DocumentVersionStatus.FinalVersion)
					{
						return RequestResult.AsError(403, "Последняя версия документа выбрана, как финальная. Создание новой версии невозможно");
					}


					var version = model.Create();

					var versionUploadResult = TryUploadFile("versionFile", FileType.Document).Result;
					if(!versionUploadResult.Success)
					{
						return versionUploadResult;
					}

					version.DocumentFilepath = versionUploadResult.Value;
					document.Versions.Add(version);

					UpdateModel(DB.Documents, document);
					return RequestResult<DocumentVersion>.AsSuccess(document.SignedDocument);
				}
			});
		}

		[HttpPut, Route("UpdateDocumentVersion")]
		public async Task<RequestResult> UpdateDocumentVersion(int documentId, DocumentVersionEditModel model)
		{
			var document = DB.Documents.FirstOrDefault(o => o.Id == documentId && !o.IsDeleted);
			var version = DB.DocumentVersions.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocumentAndVersionToEdit(document),
				() => TryUpdateModel(DB.DocumentVersions, version, model)
			});
		}



		#endregion

		#region Подписание документа

		[HttpPut, Route("SignDocument")]
		public async Task<RequestResult> SignDocument(int documentId, SignedDocumentCreateModel model)
		{
			var document = DB.Documents.FirstOrDefault(o => o.Id == documentId && !o.IsDeleted);
			var version = DB.DocumentVersions.FirstOrDefault(o => o.Id == model.VersionId && !o.IsDeleted);


			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocumentAndVersionToEdit(document,version),
				() =>
				{
			     	document.SignedDocument = model.Create();


					if(model.SignatureType == SignatureType.DigitalSignature 
						&& !DB.EDMProviders.Any(o => o.Id == model.EDMProviderId && !o.IsDeleted))
					{
						return RequestResult.AsError(404, "Провайдер ЭЦП с данным id не найден");
					}
					else if(model.SignatureType == SignatureType.TraditionalSignature)
					{
						if(!Request.Form.Files.Any(o => o.Name == "ourSigned" || o.Name == "secondSideSigned"))
						{
							return RequestResult.AsError(400, "Не загружен документ хотя бы с одной стороны");
						}

						var ourSignedFile = Request.Form.Files.FirstOrDefault(o => o.Name == "ourSigned");
						if(ourSignedFile != null)
						{
							var uploadFileResult = TryUploadFile(ourSignedFile, FileType.Document).Result;
							if(!uploadFileResult.Success) return uploadFileResult;

							document.SignedDocument.AlfateamSideDocumentScan = uploadFileResult.Value;
						}

						var secondSideSignedFile = Request.Form.Files.FirstOrDefault(o => o.Name == "secondSideSigned");
						if(secondSideSignedFile != null)
						{
							var uploadFileResult = TryUploadFile(secondSideSignedFile, FileType.Document).Result;
							if(!uploadFileResult.Success) return uploadFileResult;

							document.SignedDocument.SecondSideDocumentScan = uploadFileResult.Value;
						}
					}
					else
					{
						throw new NotImplementedException("Check for new types of SignatureType enum");
					}


					UpdateModel(DB.Documents, document);
					return RequestResult<SignedDocument>.AsSuccess(document.SignedDocument);
				}
			});
		}


		[HttpPut, Route("SetSignedDocumentFile")]
		public async Task<RequestResult> SetSignedDocumentFile(int documentId, SignedDocumentSide side)
		{
			var document = DB.Documents.Include(o => o.SignedDocument).FirstOrDefault(o => o.Id == documentId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocument(document),
				() => RequestResult.FromBoolean(document.SignedDocumentId != null,403,"Документ еще не подписан"),
				() => RequestResult.FromBoolean(document.SignedDocument.SignatureType == SignatureType.TraditionalSignature, 400,"Документ подписан ЭЦП"),
				() =>
				{
					if (!string.IsNullOrEmpty(document.SignedDocument.AlfateamSideDocumentScan)
						&& !string.IsNullOrEmpty(document.SignedDocument.SecondSideDocumentScan))
					{
						return RequestResult.AsError(403,"Документ уже подписан обоими сторонами");
					}



					if (side == SignedDocumentSide.Our)
					{
						var uploadFileResult = TryUploadFile("ourSigned", FileType.Document).Result;
						if(!uploadFileResult.Success) return uploadFileResult;

						document.SignedDocument.AlfateamSideDocumentScan = uploadFileResult.Value;
					}
					else if (side == SignedDocumentSide.SecondSide)
					{
						var uploadFileResult = TryUploadFile("secondSideSigned", FileType.Document).Result;
						if(!uploadFileResult.Success) return uploadFileResult;

						document.SignedDocument.SecondSideDocumentScan = uploadFileResult.Value;
					}
					else
					{
						throw new NotImplementedException("Check for new types of SignedDocumentSide enum");
					}


				  	 UpdateModel(DB.Documents, document);
					 return RequestResult<SignedDocument>.AsSuccess(document.SignedDocument);
				}
			});


		

		}


		[HttpPut, Route("DeleteSignedDocument")]
		public async Task<RequestResult> DeleteSignedDocument(int documentId)
		{
			var document = DB.Documents.Include(o => o.SignedDocument).FirstOrDefault(o => o.Id == documentId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocument(document),
				() => RequestResult.FromBoolean(document.SignedDocumentId != null,403,"Документ еще не подписан"),
				() => RequestResult.FromBoolean(document.SignedDocument.SignatureType == SignatureType.TraditionalSignature, 400,"Документ подписан ЭЦП"),
				() =>
				{
					if (!string.IsNullOrEmpty(document.SignedDocument.AlfateamSideDocumentScan)
						&& !string.IsNullOrEmpty(document.SignedDocument.SecondSideDocumentScan))
					{
						return RequestResult.AsError(403,"Документ уже подписан обоими сторонами");
					}

					 document.SignedDocumentId = null;
				  	 return UpdateModel(DB.Documents, document);
				}
			});




		}


		#endregion


		#endregion






		#region Private check methods

		private RequestResult CheckBaseDocument(Document document)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(document != null,404,"Сущность с данным id не найдена"),
				() => RequestResult.FromBoolean(document.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
			});
		}
		private RequestResult CheckBaseDocumentToEdit(Document document)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocument(document),
				() => RequestResult.FromBoolean(document.SignedDocumentId == null,403,"Документ уже подписан. Редактирование невозможно"),
			});
		}
		private RequestResult CheckBaseDocumentAndVersionToEdit(Document document, DocumentVersion version)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocumentToEdit(document),
				() => RequestResult.FromBoolean(version != null,404,"Версия с данным id не найдена"),
				() => RequestResult.FromBoolean(version.DocumentId == document.Id,403,"Данная версия не принадлежит текущему документу"),
			});
		}

		#endregion

	}
}
