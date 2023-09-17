using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Roles.Compliance.Appeals;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConflictEntity = Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Conflict;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance.Conflicts
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceConfilctResultsController : AbsController
	{
		public ComplianceConfilctResultsController(ControllerParams @params) : base(@params)
		{
		}

		#region Результат конфликтов

		[HttpGet, Route("GetConflictResult")]
		public async Task<RequestResult> GetConflictResult(int conflictId)
		{
			var item = DB.Conflicts.Include(o => o.Result).ThenInclude(o => o.Actions)
								   .FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilct(item),
				() => RequestResult.FromBoolean(item.ResultId != null, 403, "Результат конфликта еще не задан"),
				() => RequestResult<ConflictEntity>.AsSuccess(item.Result)
			});
		}

		[HttpPut, Route("SetConflictResult")]
		public async Task<RequestResult> SetConflictResult(int conflictId, ConflictResultCreateModel model)
		{
			var item = DB.Conflicts.Include(o => o.Sides)
								   .Include(o => o.Result).ThenInclude(o => o.Actions)
								   .FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilctToEdit(item),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var result = model.Create();
					item.Result = result;

					UpdateModel(DB.Conflicts, item);
					return RequestResult<ConflictResult>.AsSuccess(result);
				}
			});
		}


		[HttpPut, Route("SetConflictResultLocked")]
		public async Task<RequestResult> SetConflictResultLocked(int conflictId)
		{
			var item = DB.Conflicts.Include(o => o.Result)
								   .FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilct(item),
				() => RequestResult.FromBoolean(item.ResultId != null, 400, "Результат еще не задан"),
				() => RequestResult.FromBoolean(!item.Result.IsLockedForEdit, 403, "Результат обращения закрыт для редактирования"),
				() =>
				{
					item.Result.IsLockedForEdit = true;
					return UpdateModel(DB.Conflicts, item);
				}
			});
		}

		#endregion

		#region Действия по результату

		[HttpGet, Route("GetConflictResultActions")]
		public async Task<RequestResult> GetConflictResultActions(int conflictId)
		{
			var item = DB.Conflicts.Include(o => o.Result).ThenInclude(o => o.Actions)
								   .FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilct(item),
				() => RequestResult.FromBoolean(item.ResultId != null, 403, "Результат конфликта еще не задан"),
				() =>
				{
					var clientModels = ConflictResultActionClientModel.CreateItems(item.Result.Actions);
					return RequestResult<IEnumerable<ConflictResultActionClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetConflictResultAction")]
		public async Task<RequestResult> GetConflictResultAction(int conflictId, int actionId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == appealId && !o.IsDeleted);
			var action = DB.ConflictResultActions.FirstOrDefault(o => o.Id == actionId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilctAndResultAction(item, action),
				() => RequestResult<ConflictResultAction>.AsSuccess(action)
			});
		}

		[HttpPost, Route("CreateConflictResultAction")]
		public async Task<RequestResult> CreateConflictResultAction(int conflictId, ConflictResultActionCreateModel model)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilct(item),
				() => RequestResult.FromBoolean(item.ResultId != null, 400, "Результат еще не задан"),
				() => RequestResult.FromBoolean(!item.Result.IsLockedForEdit, 403, "Результат обращения закрыт для редактирования"),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var action = model.Create();
					item.Result.Actions.Add(action);

					UpdateModel(DB.Conflicts, item);
					return RequestResult<ConflictResultAction>.AsSuccess(action);
				}
			});
		}

		[HttpPut, Route("SetConflictResultActionStatus")]
		public async Task<RequestResult> SetConflictResultActionStatus(int conflictId, int actionId, ConflictResultActionStatus status)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var action = DB.ConflictResultActions.FirstOrDefault(o => o.Id == actionId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilctAndResultActionToEdit(item, action),
				() =>
				{
					action.Status = status;
					return UpdateModel(DB.ConflictResultActions, action);
				}
			});
		}

		#endregion






		#region Private check methods

		private RequestResult CheckBaseConfilct(ConflictEntity item)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(item != null,404,"Конфликт с данным id не найден"),
				() => RequestResult.FromBoolean(item.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данному конфликту"),
			});
		}
		private RequestResult CheckBaseConfilctToEdit(ConflictEntity item)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilct(item),
				() => RequestResult.FromBoolean(item.ResultId == null,403,"Конфликт уже закрыт. Редактирование невозможно"),
			});
		}



		private RequestResult CheckBaseConfilctAndResultAction(ConflictEntity item, ConflictResultAction action)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilct(item),
				() => RequestResult.FromBoolean(item.ResultId != null, 400, "Результат еще не задан"),
				() => CheckBaseResultAction(item, action),
			});
		}
		private RequestResult CheckBaseConfilctAndResultActionToEdit(ConflictEntity item, ConflictResultAction action)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilctAndResultAction(item,action),
				() => RequestResult.FromBoolean(!item.Result.IsLockedForEdit, 403, "Результат конфликта закрыт для редактирования"),
			});
		}



		private RequestResult CheckBaseResultAction(ConflictEntity item, ConflictResultAction action)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(action != null,404,"Действие с данным id не найдено"),
				() => RequestResult.FromBoolean(action.ConflictResultId == item.ResultId,403,"Действие не принадлежит данному конфликту"),
			});
		}

		#endregion
	}
}
