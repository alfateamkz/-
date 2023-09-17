using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Corruption;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Corruption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConflictEntity = Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Conflict;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance.Conflicts
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceConflictsController : AbsController
	{
		public ComplianceConflictsController(ControllerParams @params) : base(@params)
		{
		}

		#region Конфликты

		[HttpGet, Route("GetConflicts")]
		public async Task<RequestResult> GetConflicts(bool actual, int offset, int count = 20)
		{
			var queryable = DB.Conflicts.Include(o => o.Result).ThenInclude(o => o.Actions)
										.Where(o => o.ComplianceDepartmentId == this.DepartmentId);

			if (actual)
			{
				queryable = queryable.Where(o => o.ResultId == null);
			}
			else
			{
				queryable = queryable.Where(o => o.ResultId != null);
			}

			return GetMany<ConflictEntity, ConflictClientModel>(queryable, offset, count);
		}

		[HttpGet, Route("GetConflict")]
		public async Task<RequestResult> GetConflict(int id)
		{
			var item = DB.Conflicts.Include(o => o.Result).ThenInclude(o => o.Actions)
								   .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilct(item),
				() => RequestResult<ConflictResult>.AsSuccess(item)
			});
		}





		[HttpPost, Route("CreateConflict")]
		public async Task<RequestResult> CreateConflict(ConflictCreateModel model)
		{
			return TryCreateModel(DB.Conflicts, model, (item) =>
			{
				item.ComplianceDepartmentId = (int)this.DepartmentId;
				return RequestResult<ConflictEntity>.AsSuccess(item);
			});
		}

		[HttpPut, Route("UpdateConflict")]
		public async Task<RequestResult> UpdateConflict(ConflictEditModel model)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilctToEdit(item),
				() => TryUpdateModel(DB.Conflicts, item, model)
			});
		}

		[HttpDelete, Route("DeleteConflict")]
		public async Task<RequestResult> DeleteConflict(int id)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConfilctToEdit(item),
				() => DeleteModel(DB.Conflicts, item)
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

		#endregion


	}
}
