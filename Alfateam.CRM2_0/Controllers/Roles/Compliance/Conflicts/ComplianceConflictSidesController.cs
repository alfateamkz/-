using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Conflicts;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConflictEntity = Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Conflict;

namespace Alfateam.CRM2_0.Controllers.Roles.Compliance.Conflicts
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Compliance)]
	public class ComplianceConflictSidesController : AbsController
	{
		public ComplianceConflictSidesController(ControllerParams @params) : base(@params)
		{
		}

		#region Стороны конфликта

		[HttpGet, Route("GetConflictSides")]
		public async Task<RequestResult> GetConflictSides(int conflictId)
		{
			var item = DB.Conflicts.Include(o => o.Sides)
								   .FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflict(item),
				() =>
				{
					var clientModels = ConflictSideClientModel.CreateItems(item.Sides.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<ConflictSideClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetConflictSide")]
		public async Task<RequestResult> GetConflictSide(int conflictId, int sideId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var side = DB.ConflictSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndSide(item, side),
				() => RequestResult<ConflictSide>.AsSuccess(side)
			});
		}


		[HttpPost, Route("CreateConflictSide")]
		public async Task<RequestResult> CreateConflictSide(int conflictId, ConflictSideCreateModel model)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictToEdit(item),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var side = model.Create();
					item.Sides.Add(side);

					UpdateModel(DB.Conflicts, item);
					return RequestResult<ConflictSide>.AsSuccess(item);
				}
			});
		}

		[HttpPut, Route("UpdateConflictSide")]
		public async Task<RequestResult> UpdateConflictResolutionProposal(int conflictId, ConflictSideEditModel model)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var side = DB.ConflictSides.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndSideToEdit(item, side),
				() => TryUpdateModel(DB.ConflictSides, side, model)
			});
		}

		[HttpDelete, Route("DeleteConflictSide")]
		public async Task<RequestResult> DeleteConflictSide(int conflictId, int sideId)
		{
			var item = DB.Conflicts.FirstOrDefault(o => o.Id == conflictId && !o.IsDeleted);
			var side = DB.ConflictSides.FirstOrDefault(o => o.Id == sideId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndSideToEdit(item, side),
				() =>
				{
					var hasProposalsFromSide = DB.ConflictResolutionProposals.Any(o => o.ConflictId == conflictId && !o.IsDeleted && o.FromId == sideId);
					var hasFeedbacksFromSide = DB.ConflictResolutionProposalFeedbacks.Any(o => !o.IsDeleted && o.SideId == sideId);

					if(hasProposalsFromSide || hasFeedbacksFromSide)
					{
						return RequestResult.AsError(403, "Невозможно удалить сторону, т.к. она есть предложения или ответы на предложения с участием данной стороны");
					}

					return DeleteModel(DB.ConflictSides, side);
				}
			});
		}

		#endregion






		#region Private check methods

		private RequestResult CheckBaseConflict(ConflictEntity item)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(item != null,404,"Конфликт с данным id не найден"),
				() => RequestResult.FromBoolean(item.ComplianceDepartmentId == this.DepartmentId,403,"Нет доступа к данному конфликту"),
			});
		}
		private RequestResult CheckBaseConflictToEdit(ConflictEntity item)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflict(item),
				() => RequestResult.FromBoolean(item.ResultId == null,403,"Конфликт уже закрыт. Редактирование невозможно"),
			});
		}


		private RequestResult CheckBaseConflictAndSide(ConflictEntity item, ConflictSide side)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflict(item),
				() => RequestResult.FromBoolean(side != null,404,"Сторона конфликта с данным id не найдена"),
				() => RequestResult.FromBoolean(side.ConflictId == item.Id,403,"Сторона не принадлежит данному конфликту"),
			});
		}
		private RequestResult CheckBaseConflictAndSideToEdit(ConflictEntity item, ConflictSide side)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseConflictAndSide(item,side),
				() => RequestResult.FromBoolean(item.ResultId == null,403,"Конфликт уже закрыт. Редактирование невозможно"),
			});
		}

		#endregion

	}
}
