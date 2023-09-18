using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Filters;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Compliance.Law;
using Alfateam.CRM2_0.Models.ClientModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Compliance.Law;
using Alfateam.CRM2_0.Models.CreateModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.EditModels.Roles.Compliance.Law;
using Alfateam.CRM2_0.Models.EditModels.Roles.Marketing;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Compliance.Fraud;
using Alfateam.CRM2_0.Models.Roles.Compliance.Law;
using Alfateam.CRM2_0.Models.Roles.Marketing;
using Alfateam2._0.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers.Roles.Marketing
{
	[DepartmentFilter]
	[AccessActionFilter(roles: UserRole.Marketing)]
	public class MarketingAdCampaignsController : AbsMarketingController
	{
		public MarketingAdCampaignsController(ControllerParams @params) : base(@params)
		{
		}

		//TODO: Запрет редактирования после завершения РК

		

		#region Рекламные кампании

		[HttpGet, Route("GetAdCampaigns")]
		public async Task<RequestResult> GetAdCampaigns(int offset, int count = 20)
		{
			var queryable = DB.AdCampaigns.Where(o => o.MarketingDepartmentId == this.DepartmentId);
			return GetMany<AdCampaign, AdCampaignClientModel>(queryable, offset, count);
		}

		[HttpGet, Route("GetAdCampaign")]
		public async Task<RequestResult> GetAdCampaign(int id)
		{
			var item = DB.AdCampaigns.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaign(item),
				() => RequestResult<AdCampaign>.AsSuccess(item)
			});
		}





		[HttpPost, Route("CreateAdCampaign")]
		public async Task<RequestResult> CreateAdCampaign(AdCampaignCreateModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			var manager = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
								  .FirstOrDefault(o => o.Id == model.CampaignManagerId);

			//TODO: проверка, глава ли отдела????

			return TryFinishAllRequestes(new[]
			{
				() => CheckUserForMarketingRole(manager),
				() => TryCreateModel(DB.AdCampaigns, model, (item) =>
				{
					item.MarketingDepartmentId = (int)this.DepartmentId;
					return RequestResult<AdCampaign>.AsSuccess(item);
				})
			});
		}

		[HttpPut, Route("UpdateAdCampaign")]
		public async Task<RequestResult> UpdateAdCampaign(AdCampaignEditModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			var item = DB.AdCampaigns.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			var manager = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
										  .FirstOrDefault(o => o.Id == model.CampaignManagerId);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaign(item),
				() => IsUserManagerOfAdCampaign(item, authorizedUser),
				() => TryUpdateModel(DB.AdCampaigns, item, model)
			});
		}

		[HttpDelete, Route("DeleteAdCampaign")]
		public async Task<RequestResult> DeleteAdCampaign(int id)
		{
			var authorizedUser = GetAuthorizedUser();

			var item = DB.AdCampaigns.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaign(item),
				() => IsUserManagerOfAdCampaign(item, authorizedUser),
				() => DeleteModel(DB.AdCampaigns, item)
			});
		}


		#endregion

		#region Пункты рекламных кампаний

		[HttpGet, Route("GetAdCampaignItems")]
		public async Task<RequestResult> GetAdCampaignItems(int campaignId)
		{
			var campaign = DB.AdCampaigns.Include(o => o.CampaignItems)
									     .FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaign(campaign),
				() =>
				{
					var clientModels = AdCampaignItemClientModel.CreateItems(campaign.CampaignItems.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<AdCampaignItemClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetAdCampaignItem")]
		public async Task<RequestResult> GetAdCampaignItem(int campaignId, int itemId)
		{
			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndItem(campaign, item),
				() =>
				{
					var clientModel = AdCampaignItemClientModel.Create(item);
					return RequestResult<AdCampaignItemClientModel>.AsSuccess(clientModel);
				}
			});
		}




		[HttpPost, Route("CreateAdCampaignItem")]
		public async Task<RequestResult> CreateAdCampaignItem(int campaignId, AdCampaignItemCreateModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaign(campaign),
				() => IsUserManagerOfAdCampaign(campaign, authorizedUser),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var item = model.Create();

					foreach(var countryId in model.CountriesIds)
					{
						var country = DB.Countries.FirstOrDefault(o => o.Id == countryId && !o.IsDeleted);
						if(country == null)
						{
							return RequestResult.AsError(404, "Страна с данным id не найдена");
						}
						item.Countries.Add(country);
					}

					campaign.CampaignItems.Add(item);

					UpdateModel(DB.AdCampaigns, campaign);
					return RequestResult<AdCampaignItem>.AsSuccess(item);
				}
			});
		}

		[HttpPost, Route("UpdateAdCampaignItem")]
		public async Task<RequestResult> UpdateAdCampaignItem(int campaignId, AdCampaignItemEditModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);

			var item = DB.AdCampaignItems.Include(o => o.Countries)
										 .FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaign(campaign),
				() => IsUserManagerOfAdCampaign(campaign, authorizedUser),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					item.Countries.Clear();

					foreach(var countryId in model.CountriesIds)
					{
						var country = DB.Countries.FirstOrDefault(o => o.Id == countryId && !o.IsDeleted);
						if(country == null)
						{
							return RequestResult.AsError(404, "Страна с данным id не найдена");
						}
						item.Countries.Add(country);
					}

					return UpdateModel(DB.AdCampaignItems, item);
				}
			});
		}

		[HttpDelete, Route("DeleteAdCampaignItem")]
		public async Task<RequestResult> DeleteAdCampaignItem(int campaignId, int itemId)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndItem(campaign, item),
				() => IsUserManagerOfAdCampaign(campaign, authorizedUser),
				() => DeleteModel(DB.AdCampaignItems, item)
			});
		}

		#endregion

		#region Статьи бюджета рекламных кампаний
	
		[HttpGet, Route("GetAdCampaignBudgetItems")]
		public async Task<RequestResult> GetAdCampaignBudgetItems(int campaignId, int itemId)
		{
			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);

			var item = DB.AdCampaignItems.Include(o => o.BudgetItems)
										 .FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndItem(campaign, item),
				() =>
				{
					var clientModels = AdCampaignBudgetItemClientModel.CreateItems(item.BudgetItems.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<AdCampaignBudgetItemClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetAdCampaignBudgetItem")]
		public async Task<RequestResult> GetAdCampaignBudgetItem(int campaignId, int itemId, int budgetItemId)
		{
			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
			var budgetItem = DB.AdCampaignBudgetItems.FirstOrDefault(o => o.Id == budgetItemId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndBudgetItem(campaign, item,budgetItem),
				() =>
				{
					var clientModel = AdCampaignBudgetItemClientModel.Create(budgetItem);
					return RequestResult<AdCampaignBudgetItemClientModel>.AsSuccess(clientModel);
				}
			});
		}




		[HttpPost, Route("CreateAdCampaignBudgetItem")]
		public async Task<RequestResult> CreateAdCampaignBudgetItem(int campaignId, int itemId, AdCampaignBudgetItemCreateModel model)
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
					var budgetItem = model.Create();
					item.BudgetItems.Add(budgetItem);

					UpdateModel(DB.AdCampaignItems, item);
					return RequestResult<AdCampaignBudgetItem>.AsSuccess(budgetItem);
				}
			});
		}
	
		[HttpPut, Route("UpdateAdCampaignBudgetItem")]
		public async Task<RequestResult> UpdateAdCampaignBudgetItem(int campaignId, int itemId, AdCampaignBudgetItemEditModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
			var budgetItem = DB.AdCampaignBudgetItems.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndBudgetItem(campaign, item,budgetItem),
				() => IsUserManagerOfAdCampaign(campaign, authorizedUser),
				() => TryUpdateModel(DB.AdCampaignBudgetItems,budgetItem,model)
			});
		}

		[HttpDelete, Route("DeleteAdCampaignBudgetItem")]
		public async Task<RequestResult> DeleteAdCampaignBudgetItem(int campaignId, int itemId, int budgetItemId)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
			var budgetItem = DB.AdCampaignBudgetItems.FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndBudgetItem(campaign, item,budgetItem),
				() => IsUserManagerOfAdCampaign(campaign, authorizedUser),
				() => DeleteModel(DB.AdCampaignBudgetItems,budgetItem)
			});
		}


		#endregion

		#region Отчеты выполненных работ по пункты рекламных кампаний

		[HttpGet, Route("GetAdCampaignItemReports")]
		public async Task<RequestResult> GetAdCampaignItemReports(int campaignId, int itemId)
		{
			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);

			var item = DB.AdCampaignItems.Include(o => o.Reports).ThenInclude(o => o.CreatedBy)
										 .FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndItem(campaign, item),
				() =>
				{
					var clientModels = AdCampaignItemReportClientModel.CreateItems(item.Reports.Where(o => !o.IsDeleted));
					return RequestResult<IEnumerable<AdCampaignItemReportClientModel>>.AsSuccess(clientModels);
				}
			});
		}

		[HttpGet, Route("GetAdCampaignItemReport")]
		public async Task<RequestResult> GetAdCampaignItemReport(int campaignId, int itemId, int itemReportId)
		{
			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);
			var report = DB.AdCampaignItemReports.FirstOrDefault(o => o.Id == itemReportId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndItemReport(campaign, item,report),
				() =>
				{
					var clientModel = AdCampaignItemReportClientModel.Create(report);
					return RequestResult<AdCampaignItemReportClientModel>.AsSuccess(clientModel);
				}
			});
		}



		[HttpPost, Route("CreateAdCampaignItemReport")]
		public async Task<RequestResult> CreateAdCampaignItemReport(int campaignId, int itemId, AdCampaignItemReportCreateModel model)
		{
			var authorizedUser = GetAuthorizedUser();

			var campaign = DB.AdCampaigns.FirstOrDefault(o => o.Id == campaignId && !o.IsDeleted);
			var item = DB.AdCampaignItems.FirstOrDefault(o => o.Id == itemId && !o.IsDeleted);

			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaignAndItem(campaign, item),
				() => RequestResult.FromBoolean(model.IsValid(), 400, "Проверьте корректность заполнения полей"),
				() =>
				{
					var report = model.Create();
					report.CreatedById = authorizedUser.Id;
					item.Reports.Add(report);

					UpdateModel(DB.AdCampaignItems, item);
					return RequestResult<AdCampaignItemReport>.AsSuccess(report);
				}
			});
		}


		#endregion









		#region Private check methods

		private RequestResult CheckBaseAdCampaignAndBudgetItem(AdCampaign campaign, AdCampaignItem item, AdCampaignBudgetItem budgetItem)
		{
			return TryFinishAllRequestes(new[]
		{
				() => CheckBaseAdCampaignAndItem(campaign,item),
				() => RequestResult.FromBoolean(budgetItem != null,404,"Статья бюджета рекламной кампании с данным id не найдена"),
				() => RequestResult.FromBoolean(budgetItem.AdCampaignItemId == item.Id,403,"Статья бюджета рекламной кампании не принадлежит данному пункту рекламной кампании"),
			});
		}
		private RequestResult CheckBaseAdCampaignAndItemReport(AdCampaign campaign, AdCampaignItem item, AdCampaignItemReport report)
		{
			return TryFinishAllRequestes(new[]
		{
				() => CheckBaseAdCampaignAndItem(campaign,item),
				() => RequestResult.FromBoolean(report != null,404,"Отчет по пункту рекламной кампании с данным id не найден"),
				() => RequestResult.FromBoolean(report.AdCampaignItemId == item.Id,403,"Отчет не принадлежит данному пункту рекламной кампании"),
			});
		}


	

		#endregion
	}
}
