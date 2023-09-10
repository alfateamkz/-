using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Trial;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer.LegalCases
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Lawyer)]
	public class LawyerLigitationTrialRequestsController : AbsController
	{
		public LawyerLigitationTrialRequestsController(ControllerParams @params) : base(@params)
		{
		}


		#region Заявления в суд

		[HttpGet, Route("GetLitigationTrialRequests")]
		public async Task<RequestResult> GetLitigationTrialRequests(int caseId, int litigationId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.Include(o => o.TrialRequests).ThenInclude(o => o.Court).ThenInclude(o => o.Structure)
									       .Include(o => o.TrialRequests).ThenInclude(o => o.Result)
										   .FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() =>
				{
					var clientModels = TrialRequestClientModel.CreateItems(litigation.TrialRequests);
					return RequestResult<IEnumerable<TrialRequestClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetLitigationTrialRequest")]
		public async Task<RequestResult> GetLitigationTrialRequest(int caseId, int litigationId, int requestId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			var request = DB.TrialRequests.Include(o => o.Court).ThenInclude(o => o.Structure)
										  .Include(o => o.Document).ThenInclude(o => o.CreatedBy)
										  .Include(o => o.Document).ThenInclude(o => o.SignedDocument).ThenInclude(o => o.EDMProvider)
										  .Include(o => o.Document).ThenInclude(o => o.Versions)
										  .Include(o => o.Result)
										  .FirstOrDefault(o => o.Id == requestId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndRequest(legalCase,litigation, request),
				() =>
				{
					var clientModel = TrialRequestClientModel.Create(request);
					return RequestResult<TrialRequestClientModel>.AsSuccess(clientModel);
				}
			});
		}



		[HttpPost, Route("CreateLitigationTrialRequest")]
		public async Task<RequestResult> CreateLitigationTrialRequest(int caseId, int litigationId, TrialRequestCreateModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var document = DB.Documents.FirstOrDefault(o => o.Id == model.DocumentId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() => CheckBaseCourt(DB.Courts.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted)),
				() => CheckBaseDocument(document),
				() => RequestResult.FromBoolean(!document.IsUsedAnywhere, 403, "Данный документ уже прикреплен здесь или в другом месте"),
 				() =>
				{
					var request = model.Create();
					litigation.TrialRequests.Add(request);

					UpdateModel(DB.Litigations, litigation);
					return RequestResult<TrialRequest>.AsSuccess(request);
				}
			});
		}




		[HttpPut, Route("UpdateLitigationTrialRequest")]
		public async Task<RequestResult> UpdateLitigationTrialRequest(int caseId, int litigationId, TrialRequestEditModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var request = DB.TrialRequests.FirstOrDefault(o => o.Id == model.Id);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => CheckBaseLegalCaseAndRequestToEdit(legalCase,litigation, request),
 				() => TryUpdateModel(DB.TrialRequests, request, model)
			});
		}

		[HttpPut, Route("SetLitigationTrialRequestStatus")]
		public async Task<RequestResult> SetLitigationTrialRequestStatus(int caseId, int litigationId, int requestId, TrialRequestStatus status)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var request = DB.TrialRequests.FirstOrDefault(o => o.Id == requestId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => CheckBaseLegalCaseAndRequest(legalCase,litigation, request),
				() => RequestResult.FromBoolean(request.ResultId == null, 403, "Уже был задан результат, редактирование невозможно"),
				() =>
				{
					if(request.Status != Preparing && status == TrialRequestStatus.Preparing)
					{
						return RequestResult.AsError(403, "Невозможно установить статус Preparing, если заявление уже было отправлено в суд");
					}

					request.Status = status;
					return UpdateModel(DB.TrialRequests, request);
				}
			});
		}



		[HttpDelete, Route("DeleteLitigationTrialRequest")]
		public async Task<RequestResult> DeleteLitigationTrialRequest(int caseId, int litigationId, int requestId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var request = DB.TrialRequests.FirstOrDefault(o => o.Id == requestId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => CheckBaseLegalCaseAndRequestToEdit(legalCase,litigation, request),
				() => DeleteModel(DB.TrialRequests, request)
			});
		}





		#endregion

		#region Результат заявления

		[HttpPut, Route("SetLegalCaseTrialHearingResult")]
		public async Task<RequestResult> SetLegalCaseTrialHearingResult(int caseId, int litigationId, int requestId, TrialRequestResultCreateModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var request = DB.TrialRequests.FirstOrDefault(o => o.Id == requestId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndRequest(legalCase,litigation, request),
				() => RequestResult.FromBoolean(request.ResultId == null, 403, "Уже был задан результат"),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
 				() =>
				{
					if(model.Type == TrialRequestResultType.Approved && model.ScheduledHearing == null)
					{
						return RequestResult.AsError(400, "Если Type == TrialRequestResultType.Approved, то нужно создать слушание");
					}
					else if(model.Type == TrialRequestResultType.Rejected && model.ScheduledHearing != null)
					{
						return RequestResult.AsError(400, "Если Type == TrialRequestResultType.Rejected, то ScheduledHearing должно быть null");
					}


					if(model.Type == TrialRequestResultType.Approved)
					{
						var courtCheckResult = CheckBaseCourt(DB.Courts.FirstOrDefault(o => o.Id == model.CourtId && !o.IsDeleted));
						if (!courtCheckResult.Success)
						{
							return courtCheckResult;
						}

						var judgeCheckResult = CheckBaseJudge(DB.Judges.FirstOrDefault(o => o.Id == model.JudgeId && !o.IsDeleted));
						if (!judgeCheckResult.Success)
						{
							return judgeCheckResult;
						}
					}


					var result = model.Create();
					request.Result = result;

					UpdateModel(DB.TrialRequests, request);
					return RequestResult<TrialRequestResult>.AsSuccess(result);
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



		private RequestResult CheckBaseLegalCaseAndRequest(LegalCase legalCase, Litigation litigation, TrialRequest request)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase, litigation),
				() => RequestResult.FromBoolean(request != null,404, "Заявление с данным id не найдено"),
				() => RequestResult.FromBoolean(request.LitigationId == litigation.Id, 403, "Данное заявление не принадлежит текущему судебному процессу"),
			});
		}
		private RequestResult CheckBaseLegalCaseAndRequestToEdit(LegalCase legalCase, Litigation litigation, TrialRequest request)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndRequest(legalCase,litigation, request),
				() => RequestResult.FromBoolean(request.Status == TrialRequestStatus.Preparing, 403, "Заявление было уже отправлено в суд"),
				() => RequestResult.FromBoolean(request.ResultId == null, 403, "Редактирование\\удаление невозможно, т.к. уже был задан результат"),
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


		private RequestResult CheckBaseDocument(Document document)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(document != null,404,"Сущность с данным id не найдена"),
				() => RequestResult.FromBoolean(document.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
			});
		}

		#endregion
	}
}
