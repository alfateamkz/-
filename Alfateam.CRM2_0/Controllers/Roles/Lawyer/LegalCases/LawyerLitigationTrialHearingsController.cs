using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer.LegalCases
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Lawyer)]
	public class LawyerLitigationTrialHearingsController : AbsController
	{
		public LawyerLitigationTrialHearingsController(ControllerParams @params) : base(@params)
		{
		}

		#region Слушания


		[HttpGet, Route("GetLitigationTrialHearings")]
		public async Task<RequestResult> GetLitigationTrialHearings(int caseId, int litigationId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.Include(o => o.Hearings).ThenInclude(o => o.Judge).ThenInclude(o => o.Country)
										   .Include(o => o.Hearings).ThenInclude(o => o.Court).ThenInclude(o => o.Structure)
										   .Include(o => o.Hearings).ThenInclude(o => o.Result)
										   .FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() =>
				{
					var clientModels = TrialHearingClientModel.CreateItems(litigation.Hearings);
					return RequestResult<IEnumerable<TrialHearingClientModel>>.AsSuccess(clientModels);
				}
			});
		}


		[HttpGet, Route("GetLitigationTrialHearing")]
		public async Task<RequestResult> GetLitigationTrialHearing(int caseId, int litigationId, int hearingId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			
			var hearing = DB.TrialHearings.Include(o => o.Judge).ThenInclude(o => o.Country)
										  .Include(o => o.Court).ThenInclude(o => o.Structure)
										  .Include(o => o.Result)
										  .FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase,litigation, hearing),
				() =>
				{
					var clientModel = TrialHearingClientModel.Create(hearing);
					return RequestResult<TrialHearingClientModel>.AsSuccess(clientModel);
				}
			});
		}




		[HttpPost, Route("CreateLitigationTrialHearing")]
		public async Task<RequestResult> CreateLitigationTrialHearing(int caseId, int litigationId, TrialHearingCreateModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() => CheckBaseCourt(DB.Courts.FirstOrDefault(o => o.Id == model.CourtId && !o.IsDeleted)),
				() => CheckBaseJudge(DB.Judges.FirstOrDefault(o => o.Id == model.JudgeId && !o.IsDeleted)),
 				() =>
				{
					var hearing = model.Create();
					litigation.Hearings.Add(hearing);

					UpdateModel(DB.Litigations, litigation);
					return RequestResult<TrialHearing>.AsSuccess(hearing);
				}
			});
		}

		[HttpPut, Route("UpdateLitigationTrialHearing")]
		public async Task<RequestResult> UpdateLitigationTrialHearing(int caseId, int litigationId, TrialHearingEditModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var hearing = DB.TrialHearings.FirstOrDefault(o => o.Id == model.Id);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase, litigation, hearing),
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => RequestResult.FromBoolean(hearing.ResultId == null, 403, "Редактирование невозможно, т.к. был задан результат"),
				() => CheckBaseCourt(DB.Courts.FirstOrDefault(o => o.Id == model.CourtId && !o.IsDeleted)),
				() => CheckBaseJudge(DB.Judges.FirstOrDefault(o => o.Id == model.JudgeId && !o.IsDeleted)),
 				() => TryUpdateModel(DB.TrialHearings, hearing, model)
			});
		}

		[HttpDelete, Route("DeleteLitigationTrialHearing")]
		public async Task<RequestResult> DeleteLitigationTrialHearing(int caseId, int litigationId, int hearingId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var hearing = DB.TrialHearings.FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase,litigation, hearing),
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => RequestResult.FromBoolean(hearing.ResultId == null, 403, "Редактирование невозможно, т.к. был задан результат"),
 				() => DeleteModel(DB.TrialHearings, hearing)
			});
		}



		#endregion

		#region Результат слушания


		[HttpPost, Route("CreateLitigationHearingResult")]
		public async Task<RequestResult> CreateLitigationHearingResult(int caseId, int litigationId, int hearingId, TrialHearingResultCreateModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var hearing = DB.TrialHearings.FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase,litigation, hearing),
				() => RequestResult.FromBoolean(hearing.ResultId == null, 403, "Редактирование невозможно, т.к. был задан результат"),
 				() =>
				{
					var result = model.Create();
					hearing.Result = result;

					UpdateModel(DB.TrialHearings, hearing);
					return RequestResult<TrialHearingResult>.AsSuccess(result);
				}
			});
		}


		[HttpPut, Route("UpdateLitigationHearingResult")]
		public async Task<RequestResult> UpdateLitigationHearingResult(int caseId, int litigationId, int hearingId, TrialHearingResultEditModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			var hearing = DB.TrialHearings.Include(o => o.Result)
										  .FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase,litigation, hearing),
				() => RequestResult.FromBoolean(hearing.ResultId != null, 403, "Редактирование невозможно, т.к. не был еще задан результат"),
				() => RequestResult.FromBoolean(hearing.Result.IsLockedForChanges == false, 403, "Редактирование невозможно, т.к. результат был утвержден"),
 				() => TryUpdateModel(DB.TrialHearingResults, hearing.Result, model)
			});
		}


		[HttpPut, Route("LockLitigationHearingResult")]
		public async Task<RequestResult> LockLitigationHearingResult(int caseId, int litigationId, int hearingId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			var hearing = DB.TrialHearings.Include(o => o.Result)
										  .FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase,litigation, hearing),
				() => RequestResult.FromBoolean(hearing.ResultId != null, 403, "Редактирование невозможно, т.к. не был еще задан результат"),
 				() =>
				{
					hearing.Result.IsLockedForChanges = true;
					return UpdateModel(DB.TrialHearingResults, hearing.Result);
				}
			});
		}


		#endregion

		#region Документы к результату слушания



		[HttpGet, Route("GetLegalCaseTrialHearingResultDocuments")]
		public async Task<RequestResult> GetLegalCaseTrialHearingResultDocuments(int caseId, int litigationId, int hearingId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			var hearing = DB.TrialHearings.Include(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.Versions)
										  .Include(o => o.Result).ThenInclude(o => o.Documents).ThenInclude(o => o.SignedDocument).ThenInclude(o => o.EDMProvider)
										  .FirstOrDefault(o => o.Id == hearingId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase,litigation, hearing),
				() => RequestResult.FromBoolean(hearing.ResultId != null, 400, "Результат судебного слушания еще не был задан"),
 				() =>
				{
					var clientModels = DocumentClientModel.CreateItems(hearing.Result.Documents.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<DocumentClientModel>>.AsSuccess(clientModels);
				}
			});
		}



		[HttpPost, Route("AddLegalCaseTrialHearingResultDocument")]
		public async Task<RequestResult> AddLegalCaseTrialHearingResultDocument(int caseId, int litigationId, int hearingId, int documentId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			var hearing = DB.TrialHearings.Include(o => o.Result)
										  .FirstOrDefault(o => o.Id == hearingId);

			var document = DB.Documents.FirstOrDefault(o => o.Id == documentId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase,litigation,hearing),
				() => RequestResult.FromBoolean(hearing.ResultId != null, 400, "Результат судебного слушания еще не был задан"),
				() => CheckBaseDocument(document),
				() => RequestResult.FromBoolean(!document.IsUsedAnywhere, 403, "Данный документ уже прикреплен здесь или в другом месте"),
				() =>
				{
					hearing.Result.Documents.Add(document);
					return UpdateModel(DB.TrialHearings, hearing);
				}
			});
		}

		[HttpDelete, Route("DeleteLegalCaseTrialHearingResultDocument")]
		public async Task<RequestResult> DeleteLegalCaseTrialHearingResultDocument(int caseId, int litigationId, int hearingId, int documentId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			var hearing = DB.TrialHearings.Include(o => o.Result)
										  .FirstOrDefault(o => o.Id == hearingId);

			var document = DB.Documents.FirstOrDefault(o => o.Id == documentId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndHearing(legalCase,litigation, hearing),
				() => CheckBaseDocumentAndHearingResult(document, hearing.Result),
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
		private RequestResult CheckBaseLegalCaseAndLitigation(LegalCase legalCase, Litigation litigation)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCase(legalCase),
				() => RequestResult.FromBoolean(litigation != null,404, "Судебное разбирательство с данным id не найдено"),
				() => RequestResult.FromBoolean(litigation.LegalCaseId == legalCase.Id, 403, "Данное судебное разбирательство не принадлежит текущему юридическому делу"),
			});
		}
		private RequestResult CheckBaseLegalCaseAndLitigationToEdit(LegalCase legalCase, Litigation litigation)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() => RequestResult.FromBoolean(litigation.ResultId == null,404, "Редактирование невозможно. Судебное разбирательство завершено"),
			});
		}



		private RequestResult CheckBaseLegalCaseAndHearing(LegalCase legalCase, Litigation litigation, TrialHearing hearing)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() => RequestResult.FromBoolean(hearing != null,404, "Слушание с данным id не найдено"),
				() => RequestResult.FromBoolean(hearing.LitigationId == litigation.Id, 403, "Данное слушание не принадлежит текущему судебному процессу"),
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
		private RequestResult CheckBaseDocumentAndHearingResult(Document document, TrialHearingResult result)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseDocument(document),
				() => RequestResult.FromBoolean(result != null,400,"Результат еще не был задан"),
				() => RequestResult.FromBoolean(document.TrialHearingResultId == result.Id,403,"Данный документ не прикреплен к текущему слушанию"),
			});
		}


		private RequestResult CheckBaseCourt(Court court)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(court != null,404,"Суд с данным id не найден"),
				() => RequestResult.FromBoolean(court.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данному суду"),
			});
		}
		private RequestResult CheckBaseJudge(Judge judge)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(judge != null,404,"Судья с данным id не найден"),
				() => RequestResult.FromBoolean(judge.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данному судье"),
			});
		}

		#endregion
	}
}
