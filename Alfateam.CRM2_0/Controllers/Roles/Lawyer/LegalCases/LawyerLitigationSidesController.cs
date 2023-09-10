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
	public class LawyerLitigationSidesController : AbsController
	{
		public LawyerLitigationSidesController(ControllerParams @params) : base(@params)
		{
		}


		#region Стороны судебного процесса

		[HttpGet, Route("GetLitigationSides")]
		public async Task<RequestResult> GetLitigationSides(int caseId,int litigationId)
		{
			var legalCase = DB.LegalCases.Include(o => o.Litigation).ThenInclude(o => o.Sides)
										 .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() =>
				{
					var clientModels = TrialProcessSideClientModel.CreateItems(litigation.Sides);
					return RequestResult<IEnumerable<TrialProcessSideClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetLitigationSide")]
		public async Task<RequestResult> GetLitigationSide(int caseId, int litigationId, int sideId)
		{
			var legalCase = DB.LegalCases.Include(o => o.Litigation).ThenInclude(o => o.Sides)
										 .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var side = DB.TrialProcessSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndSide(legalCase,litigation, side),
				() =>
				{
					var clientModel = TrialProcessSideClientModel.Create(side);
					return RequestResult<TrialProcessSideClientModel>.AsSuccess(clientModel);
				}
			});
		}





		[HttpPost, Route("CreateLegalCaseLigitationSide")]
		public async Task<RequestResult> CreateLegalCaseLigitationSide(int caseId, int litigationId, TrialProcessSideCreateModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			var litigation = DB.Litigations.Include(o => o.Sides)
										   .FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
 				() =>
				{
					if(model.Role == TrialProcessSideRole.Plaintiff
						|| model.Role == TrialProcessSideRole.Defendant)
					{
						return RequestResult.AsError(403, "Невозможно создать сторону ответчика или истца");
					}
					else if(model.Role != TrialProcessSideRole.Other
						&& litigation.Sides.Any(o => o.Role == model.Role && !o.IsDeleted))
					{
						//Предусматриваем появление новых ролей
						return RequestResult.AsError(400, "Сторона с данной ролью уже была ранее создана");
					}

					var side = model.Create();
					litigation.Sides.Add(side);

					UpdateModel(DB.Litigations, litigation);
					return RequestResult<TrialProcessSide>.AsSuccess(side);
				}
			});
		}

		[HttpPut, Route("UpdateLegalCaseLigitationSide")]
		public async Task<RequestResult> UpdateLegalCaseLigitationSide(int caseId, int litigationId, TrialProcessSideEditModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var side = DB.TrialProcessSides.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndSide(legalCase,litigation, side),
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
 				() => TryUpdateModel(DB.TrialProcessSides, side, model)
			});
		}

		[HttpDelete, Route("DeleteLegalCaseLigitationSide")]
		public async Task<RequestResult> DeleteLegalCaseLigitationTrialRequest(int caseId, int litigationId, int sideId)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			var litigation = DB.Litigations.FirstOrDefault(o => o.Id == litigationId && !o.IsDeleted);
			var side = DB.TrialProcessSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndSide(legalCase,litigation, side),
				() => CheckBaseLegalCaseAndLitigationToEdit(legalCase, litigation),
				() =>
				{
					if(side.Role == TrialProcessSideRole.Plaintiff
					|| side.Role == TrialProcessSideRole.Defendant)
					{
						return RequestResult.AsError(403, "Невозможно удалить сторону ответчика или истца");
					}
					return DeleteModel(DB.TrialProcessSides, side);
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

		private RequestResult CheckBaseLegalCaseAndSide(LegalCase legalCase, Litigation litigation, TrialProcessSide side)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseAndLitigation(legalCase,litigation),
				() => RequestResult.FromBoolean(side != null,404, "Сторона с данным id не найдена"),
				() => RequestResult.FromBoolean(side.LitigationId == litigation.Id, 403, "Данное слушание не принадлежит текущему судебному процессу"),
			});
		}


		#endregion

	}
}
