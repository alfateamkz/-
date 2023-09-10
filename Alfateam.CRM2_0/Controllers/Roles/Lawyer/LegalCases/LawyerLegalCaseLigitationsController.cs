using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Litigations;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Documents;
using Alfateam.Website.API.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.LegalCases;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer.LegalCases
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Lawyer)]
	public class LawyerLegalCaseLigitationsController : AbsController
	{
		public LawyerLegalCaseLigitationsController(ControllerParams @params) : base(@params)
		{
		}

		#region Судебный процесс

		[HttpGet, Route("GetLitigations")]
		public async Task<RequestResult> GetLitigations(int caseId)
		{
			var legalCase = DB.LegalCases.Include(o => o.Litigations).ThenInclude(o => o.Sides).ThenInclude(o => o.Participants)
										 .Include(o => o.Litigations).ThenInclude(o => o.TrialRequests)
										 .Include(o => o.Litigations).ThenInclude(o => o.Hearings)
										 .Include(o => o.Litigations).ThenInclude(o => o.Result)
										 .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCase(legalCase),
				() => RequestResult<IEnumerable<Litigation>>.AsSuccess(legalCase.Litigations)
			});
		}

		[HttpGet, Route("GetLitigation")]
		public async Task<RequestResult> GetLitigation(int caseId, int litigationId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.Include(o => o.Sides).ThenInclude(o => o.Participants)
										   .Include(o => o.TrialRequests)
										   .Include(o => o.Hearings)
										   .Include(o => o.Result)
										   .FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase, litigation),
				() => RequestResult<Litigation>.AsSuccess(litigation)
			});
		}



		[HttpPost, Route("CreateLitigation")]
		public async Task<RequestResult> CreateLitigation(int caseId, LitigationType type)
		{
			var legalCase = DB.LegalCases.Include(o => o.Litigations)
									     .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseToEdit(legalCase),
				() => RequestResult.FromBoolean(legalCase.Procedure == LegalCaseProcedure.Trial, 403, "Дело не имеет судебный порядок"),
				() =>
				{
					var lastLitigation = legalCase.Litigations.LastOrDefault(o => !o.IsDeleted);
					if(lastLitigation != null && lastLitigation.ResultId == null)
					{
						return RequestResult.AsError(400, "Невозможно создать новое разбирательство, пока не закрыто старое");
					}


					var litigation = CreateLitigation(type);
					legalCase.Litigations.Add(litigation);

					UpdateModel(DB.LegalCases, legalCase);
					return RequestResult<Litigation>.AsSuccess(litigation);
				}
			});
		}


		#endregion

		#region Результат судебного процесса

		[HttpGet, Route("GetLitigationResult")]
		public async Task<RequestResult> GetLitigationResult(int caseId,int litigationId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.Include(o => o.Result)
										   .FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase, litigation),
				() => RequestResult.FromBoolean(litigation.ResultId != null, 400, "Результат судебного процесса еще не был задан"),
				() =>
				{
					var clientModel = TrialProcessResultClientModel.Create(litigation.Result);
					return RequestResult<TrialProcessResultClientModel>.AsSuccess(clientModel);
				}
			});
		}

		[HttpPut, Route("SetLitigationResult")]
		public async Task<RequestResult> SetLitigationResult(int caseId, int litigationId, TrialProcessResultCreateModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.Include(o => o.Result)
										   .FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			return CheckBaseLegalCaseToEdit(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase, litigation),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() => RequestResult.FromBoolean(litigation.ResultId == null,403, "Результат судебного разбирательства уже был задан"),
				() =>
				{
					litigation.Result = model.Create();
					UpdateModel(DB.Litigations, litigation);

					return RequestResult.AsSuccess<TrialProcessResult>(litigation.Result);
				}
			});
		}

		#endregion

		#region Документы к результату судебного процесса


		[HttpGet, Route("GetLitigationResultDocuments")]
		public async Task<RequestResult> GetLitigationResultDocuments(int caseId, int litigationId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.Include(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.SignedDocument).ThenInclude(o => o.EDMProvider)
										   .Include(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.Versions)
										   .Include(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.CreatedBy)
										   .FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase, litigation),
				() => RequestResult.FromBoolean(litigation.ResultId != null, 400, "Результат судебного процесса еще не был задан"),
				() =>
				{
					var clientModels = DocumentClientModel.CreateItems(litigation.Result.Documents.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<DocumentClientModel>>.AsSuccess(clientModel);
				}
			});
		}

		[HttpPost, Route("AddLitigationResultDocument")]
		public async Task<RequestResult> AddLitigationResultDocument(int caseId, int litigationId, int documentId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.Include(o => o.Result)
										   .FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			var document = DB.Documents.FirstOrDefault(o => o.Id == documentId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase, litigation),
				() => RequestResult.FromBoolean(litigation.ResultId != null, 400, "Результат судебного процесса еще не был задан"),
				() => CheckBaseDocument(document),
				() => RequestResult.FromBoolean(!document.IsUsedAnywhere, 403, "Данный документ уже прикреплен здесь или в другом месте"),
				() =>
				{
					litigation.Result.Documents.Add(document);
					return UpdateModel(DB.Litigations, litigation);
				}
			});
		}


		[HttpDelete, Route("DeleteLitigationResultDocument")]
		public async Task<RequestResult> DeleteLitigationResultDocument(int caseId, int litigationId, int documentId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.Include(o => o.Result)
										   .FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			var document = DB.Documents.FirstOrDefault(o => o.Id == documentId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase, litigation),
				() => CheckBaseDocumentAndLitigationResult(document, litigation.Result),
				() =>
				{
					document.IsDeleted = true;
					return DeleteModel(DB.Documents, document);
				}
			});
		}
		#endregion







		#region Private check methods

		private RequestResult CheckBaseLegalCase(LegalCase legalCase)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(legalCase != null,404,"Юридическое дело с данным id не найдено"),
				() => RequestResult.FromBoolean(legalCase.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данному юридическому делу"),
			});
		}
		private RequestResult CheckBaseLegalCaseToEdit(LegalCase legalCase)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCase(legalCase),
				() => RequestResult.FromBoolean(legalCase.ResultId == null,403,"Редактирование невозможно. Дело завершено"),
			});
		}
		private RequestResult CheckBaseLegalCaseAndLitigation(LegalCase legalCase, Litigation litigation)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCase(legalCase),
				() => RequestResult.FromBoolean(litigation != null,404, "Судебное разбирательство с данным id не найдено"),
				() => RequestResult.FromBoolean(litigation.LegalCaseId == legalCase.Id, 403, "Данное судебное разбирательство не принадлежит текущему юридическому делу"),
			});
		}



		private RequestResult CheckBaseDocument(Document document)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(document != null,404,"Сущность с данным id не найдена"),
				() => RequestResult.FromBoolean(document.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
			});
		}
		private RequestResult CheckBaseDocumentAndLitigationResult(Document document, TrialProcessResult result)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocument(document),
				() => RequestResult.FromBoolean(result != null,400,"Результат еще не был задан"),
				() => RequestResult.FromBoolean(document.TrialProcessResultId == result.Id,403,"Данный документ не прикреплен к текущему результату судебного процесса"),
			});
		}


		#endregion

		#region Other methods

		public static Litigation CreateLitigation(LitigationType type)
		{
			//TODO: когда проработаем модели, подумать

			Litigation litigation;


			switch (type)
			{
				case LitigationType.Administrative:
					litigation = new AdministrativeLitigation();
					break;
				case LitigationType.Arbitration:
					litigation = new ArbitrationLitigation();
					break;
				case LitigationType.Civil:
					litigation = new CivilLitigation();
					break;
				case LitigationType.Constitutional:
					litigation = new ConstitutionalLitigation();
					break;
				case LitigationType.Criminal:
					litigation = new CriminalLitigation();
					break;
				default:
					throw new NotImplementedException("Check for new Litigation inheritors");
			}

			litigation.Sides.Add(new TrialProcessSide
			{
				Title = "Истцы",
				Role = TrialProcessSideRole.Plaintiff
			});
			litigation.Sides.Add(new TrialProcessSide
			{
				Title = "Ответчики",
				Role = TrialProcessSideRole.Defendant
			});
		}
		private void IncludeLigitationFields(Litigation ligitation)
		{
			ligitation.Sides = ligitation.Sides.Where(o => !o.IsDeleted).ToList();
			foreach (var side in ligitation.Sides)
			{
				side.Participants = side.Participants.ToList();
			}


			ligitation.TrialRequests = ligitation.TrialRequests.Where(o => !o.IsDeleted).ToList();
			ligitation.Hearings = ligitation.Hearings.Where(o => !o.IsDeleted).ToList();


			if (ligitation is AdministrativeLitigation administrativeLigitation)
			{

			}
			else if (ligitation is ArbitrationLitigation arbitrationLigitation)
			{

			}
			else if (ligitation is CivilLitigation civilLigitation)
			{

			}
			else if (ligitation is ConstitutionalLitigation constititionalLigitation)
			{

			}
			else if (ligitation is CriminalLitigation criminalLigitation)
			{

			}
			else
			{
				throw new NotImplementedException("Check for new Litigation inheritors");
			}
		}

		#endregion

	}
}
