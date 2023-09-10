using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.LegalCases;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.CRM2_0.Models.EditModels.Roles.Lawyer.LegalCases;

namespace Alfateam.CRM2_0.Controllers.Roles.Lawyer.LegalCases
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Lawyer)]
	public class LawyerLegalCasesController : AbsController
	{
		public LawyerLegalCasesController(ControllerParams @params) : base(@params)
		{
		}

		//TODO: Проверка результатов всех слушаний, чтобы закрыть судебное разбирательство
		//TODO: Проверка результатов всех судебных разбирательств, чтобы закрыть юридическое дело
		//TODO: получение по цепочке

		#region Юридические дела

		[HttpGet, Route("GetLegalCases")]
		public async Task<RequestResult> GetLegalCases(bool showActual, int offset, int count = 20)
		{
			var legalCases = DB.LegalCases.Where(o => o.LawDepartmentId == DepartmentId
															 && !o.IsDeleted)
										  .Include(o => o.CreatedBy)
										  .Include(o => o.SecondSide)
										  .Include(o => o.Result)
										  .AsEnumerable();

			if (showActual)
			{
				legalCases = checkings.Where(o => o.ResultId == null);
			}
			else
			{
				legalCases = checkings.Where(o => o.ResultId != null);
			}

			legalCases = legalCases.Skip(offset).Take(count).ToList();
			return RequestResult<IEnumerable<LegalCase>>.AsSuccess(legalCases);
		}

		[HttpGet, Route("GetLegalCase")]
		public async Task<RequestResult> GetLegalCase(int id)
		{
			var legalCase = DB.LegalCases.Include(o => o.CreatedBy)
										 .Include(o => o.SecondSide)
										 .Include(o => o.Result)
										 .FirstOrDefault(o => o.Id == id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCase(legalCase),
				() => RequestResult<LegalCase>.AsSuccess(legalCase)
			});
		}


		[HttpPost, Route("CreateLegalCase")]
		public async Task<RequestResult> CreateLegalCase(LegalCaseCreateModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			if (model.SecondSideId != null)
			{
				var needToCheckUser = DB.Users.FirstOrDefault(o => o.Id == model.CheckedPersonId);
				if (needToCheckUser == null)
				{
					return RequestResult.AsError(404, "Пользователь с данным id не найден");
				}
				else if (needToCheckUser.BusinessId != this.BusinessId)
				{
					return RequestResult.AsError(403, "Нет доступа к данному пользователю");
				}
			}

			return TryCreateModel(DB.LegalCases, model, async (item) =>
			{
				item.CreatedById = authorizedUser.Id;
				item.LawDepartmentId = this.DepartmentId;
			});
		}

		[HttpPut, Route("UpdateLegalCase")]
		public async Task<RequestResult> UpdateLegalCase(LegalCaseEditModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseToEdit(legalCase),
				() => RequestResult.FromBoolean(legalCase.Procedure != LegalCaseProcedure.Trial, 403, "Дело уже имеет судебный порядок. Невозможно редактирование"),
				() => TryUpdateModel(DB.LegalCases, legalCase, model)
			});
		}

		//TODO: подумать над методом изменения юридического дела

		#endregion

		#region Изменение порядка ведения юридического дела

		[HttpPut, Route("SetNonTrialLegalCaseProcedure")]
		public async Task<RequestResult> SetNonTrialLegalCaseProcedure(int caseId, LegalCaseProcedure procedure)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseToEdit(legalCase),
				() => RequestResult.FromBoolean(legalCase.Procedure != LegalCaseProcedure.Trial, 403, "Дело уже имеет судебный порядок. Невозможно изменить статус"),
				() => RequestResult.FromBoolean(procedure != LegalCaseProcedure.Trial, 403, "Для LegalCaseProcedure.Trial есть другой метод"),
				() =>
				{
					legalCase.Procedure = procedure;
					return UpdateModel(DB.LegalCases, legalCase);
				}
			});
		}

		[HttpPut, Route("SetTrialLegalCaseProcedure")]
		public async Task<RequestResult> SetTrialLegalCaseProcedure(int caseId, LitigationType type)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCaseToEdit(legalCase),
				() => RequestResult.FromBoolean(legalCase.Procedure != LegalCaseProcedure.Trial, 403, "Дело уже имеет судебный порядок. Невозможно изменить статус"),
				() =>
				{
					legalCase.Procedure = LegalCaseProcedure.Trial;

					var newLitigation = LawyerLegalCaseLigitationsController.CreateLitigation(type);
					legalCase.Litigations.Add(newLitigation);

					UpdateModel(DB.LegalCases, legalCase);
					return RequestResult<Litigation>.AsSuccess(legalCase.Litigation);
				}
			});
		}

		#endregion

		#region Результат юридического дела

		[HttpPut, Route("GetLegalCaseResult")]
		public async Task<RequestResult> GetLegalCaseResult(int caseId)
		{
			var legalCase = DB.LegalCases.Include(o => o.Result)
										 .FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);

			return CheckBaseLegalCaseToEdit(new[]
			{
				() => CheckBaseLegalCase(legalCase),
				() => RequestResult.FromBoolean(legalCase.ResultId != null,400,"Результат дела еще не был задан"),
				() =>
				{
					var clientModel = LegalCaseResultClientModel.Create(legalCase.Result);
					return RequestResult<LegalCaseResultClientModel>.AsSuccess(clientModel);
				}
			});
		}


		[HttpPut, Route("SetLegalCaseResult")]
		public async Task<RequestResult> SetLegalCaseResult(int caseId, LegalCaseResultCreateModel model)
		{
			var legalCase = DB.LegalCases.FirstOrDefault(o => o.Id == caseId && !o.IsDeleted);
			return CheckBaseLegalCaseToEdit(new[]
			{
				() => CheckBaseLegalCase(legalCase),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() => RequestResult.FromBoolean(legalCase.ResultId == null,403,"Результат дела уже был задан"),
				() =>
				{
					legalCase.Result = model.Create();
					UpdateModel(DB.LegalCases, legalCase);

					return RequestResult.AsSuccess<LegalCaseResult>(legalCase.Result);
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
				() => RequestResult.FromBoolean(legalCase.LawDepartmentId == this.DepartmentId,403,"Нет доступа к данной сущности"),
			});
		}
		private RequestResult CheckBaseLegalCaseToEdit(LegalCase legalCase)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseLegalCase(legalCase),
				() => RequestResult.FromBoolean(legalCase.ResultId == null, 403, "Редактирование невозможно. Дело закрыто")
			});
		}

		#endregion
	}
}
