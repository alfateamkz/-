using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.CreateModels.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.EditModels.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.EditModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Marketing
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Marketing)]
	public class MarketingTasksController : AbsMarketingController
	{
        public MarketingTasksController(ControllerParams @params) : base(@params)
        {
        }

		//TODO: Запрет редактирования после завершения РК


		#region Задачи пункта рекламной кампании

		[HttpGet, Route("GetAdCampaignItemTasks")]
		public async Task<RequestResult> GetAdCampaignItemTasks(int campaignId, int itemId)
		{
			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);

			var item = DB.AdCampaignItems.Include(o => o.Tasks)
										 .FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndItem(campaign, item),
				() =>
				{
					var clientModels = BaseAdCampaignItemTaskClientModel.CreateItems(item.Tasks.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<BaseAdCampaignItemTaskClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetAdCampaignItemTask")]
		public async Task<RequestResult> GetAdCampaignItemTask(int campaignId, int itemId, int taskId)
		{
			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
			var task = DB.BaseAdCampaignItemTasks.FirstOrDefault(o => o.Id == taskId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndTask(campaign, item, task),
				() =>
				{
					var clientModel = BaseAdCampaignItemTaskClientModel.Create(task);
					return RequestResult<BaseAdCampaignItemTaskClientModel>.AsSuccess(clientModel);
				}
			});
		}





		[HttpPost, Route("CreateAdCampaignItemTask")]
		public async Task<RequestResult> CreateAdCampaignItemTask(int campaignId, int itemId, BaseAdCampaignItemTaskCreateModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndItem(campaign, item),
				() => IsUserManagerOfAdCampaign(campaign, authorizedUser),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var task = model.Create();
					item.Tasks.Add(task);

					UpdateModel(DB.AdCampaignItems, item);
					return RequestResult<BaseAdCampaignItemTask>.AsSuccess(task);
				}
			});
		}

		[HttpPut, Route("UpdateAdCampaignItemTask")]
		public async Task<RequestResult> UpdateAdCampaignItemTask(int campaignId, int itemId, BaseAdCampaignItemTaskEditModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
			var task = DB.BaseAdCampaignItemTasks.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndTask(campaign, item,task),
				() => IsUserManagerOfAdCampaign(campaign, authorizedUser),
				() => TryUpdateModel(DB.BaseAdCampaignItemTasks,task,model)
			});
		}

		[HttpDelete, Route("DeleteAdCampaignItemTask")]
		public async Task<RequestResult> DeleteAdCampaignItemTask(int campaignId, int itemId, int taskId)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
			var task = DB.BaseAdCampaignItemTasks.FirstOrDefault(o => o.Id == taskId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndTask(campaign, item,task),
				() => IsUserManagerOfAdCampaign(campaign, authorizedUser),
				() => DeleteModel(DB.BaseAdCampaignItemTasks,task)
			});
		}

		#endregion

		#region Изменение статуса\прогресса задачи сотрудником

		[HttpPut, Route("SendToCheckAdCampaignItemTaskStatus")]
		public async Task<RequestResult> SendToCheckAdCampaignItemTaskStatus(int campaignId, int itemId, int taskId, AdCampaignItemTaskStatus status, string comment = null)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
			var task = DB.BaseAdCampaignItemTasks.FirstOrDefault(o => o.Id == taskId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndTask(campaign, item,task),
				() => IsUserWorkingOnAdCampaignItem(campaign, item, authorizedUser),
				() =>
				{
					task.CheckRequests.Add(new AdCampaignItemTaskCheckRequest
					{
						Status = status,
						Comment = comment,
						FromId = authorizedUser.Id
					});
					return UpdateModel(DB.BaseAdCampaignItemTasks ,task);
				}
			});
		}

		[HttpPut, Route("SetAdCampaignItemTaskProgress")]
		public async Task<RequestResult> SetAdCampaignItemTaskProgress(int campaignId, int itemId, int taskId, double completed)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
			var task = DB.BaseAdCampaignItemTasks.FirstOrDefault(o => o.Id == taskId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndTask(campaign, item,task),
				() => RequestResult.FromBoolean(task is CounterAdCampaignItemTask, 400, "Данная задача не имеет счетчика выполнения"),
				() => IsUserWorkingOnAdCampaignItem(campaign, item, authorizedUser),
				() =>
				{
					(task as CounterAdCampaignItemTask).Completed = completed;
					return UpdateModel(DB.BaseAdCampaignItemTasks ,task);
				}
			});
		}

		#endregion

		#region Изменение статуса\прогресса задачи менеджером

		[HttpPut, Route("SetAdCampaignItemTaskCheckResult")]
		public async Task<RequestResult> SetAdCampaignItemTaskCheckResult(int campaignId, int itemId, int taskId,int checkReqId, AdCampaignItemTaskCheckRequestResultCreateModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
			var task = DB.BaseAdCampaignItemTasks.FirstOrDefault(o => o.Id == taskId && !o.IsDeleted);
			var taskCheckReq = DB.AdCampaignItemTaskCheckRequests.FirstOrDefault(o => o.Id == checkReqId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndTaskCheckReq(campaign, item,task,taskCheckReq),
				() => IsUserManagerOfAdCampaign(campaign, authorizedUser),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() => RequestResult.FromBoolean(taskCheckReq.ResultId == null, 403, "Результат запроса на проверку уже задан"),
				() =>
				{
					var result = model.Create();
					taskCheckReq.Result = result;

					UpdateModel(DB.AdCampaignItemTaskCheckRequests ,taskCheckReq);
					return RequestResult<AdCampaignItemTaskCheckRequestResult>.AsSuccess(result);
				}
			});
		}


		#endregion


		#region Private check methods

		private RequestResult CheckBaseAdCampaignAndTask(AdCampaign campaign, AdCampaignItem item, BaseAdCampaignItemTask task)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndItem(campaign,item),
				() => RequestResult.FromBoolean(task != null,404,"Задача с данным id не найдена"),
				() => RequestResult.FromBoolean(task.AdCampaignItemId == item.Id,403,"Задача не принадлежит данному пункту рекламной кампании"),
			});
		}
		private RequestResult CheckBaseAdCampaignAndTaskCheckReq(AdCampaign campaign, AdCampaignItem item, BaseAdCampaignItemTask task, AdCampaignItemTaskCheckRequest request)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndTask(campaign,item, task),
				() => RequestResult.FromBoolean(request != null,404,"Запрос на проверку с данным id не найден"),
				() => RequestResult.FromBoolean(request.BaseAdCampaignItemTaskId == task.Id,403,"Запрос на проверку не принадлежит данной задаче"),
			});
		}

		#endregion
	}
}
