using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.Enums;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Marketing;

namespace Alfateam.CRM2_0.Abstractions
{
	public abstract class AbsMarketingController : AbsController
	{
		public AbsMarketingController(ControllerParams @params) : base(@params)
		{
		}



		protected RequestResult CheckBaseAdCampaign(AdCampaign campaign)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(campaign != null,404,"Рекламная кампания с данным id не найдена"),
				() => RequestResult.FromBoolean(campaign.MarketingDepartmentId == this.DepartmentId,403,"Нет доступа к данной рекламной кампании"),
			});
		}
		protected RequestResult CheckBaseAdCampaignAndItem(AdCampaign campaign, AdCampaignItem item)
		{
			return TryFinishAllRequestes(new[]
			{
				() => CheckBaseAdCampaign(campaign),
				() => RequestResult.FromBoolean(item != null,404,"Пункт рекламной кампании с данным id не найден"),
				() => RequestResult.FromBoolean(item.AdCampaignId == campaign.Id,403,"Пункт рекламной кампании не принадлежит данной рекламной кампании"),
			});
		}




		protected RequestResult CheckUserForMarketingRole(User manager)
		{
			return TryFinishAllRequestes(new[]
			{
				() => RequestResult.FromBoolean(manager.BusinessId == this.BusinessId, 403, "Нет доступа к данному пользователю"),
				() => RequestResult.FromBoolean(IsInRole(manager,UserRole.Marketing),403,"Пользователь, выбранный в качестве менеджера не может им быть")
			});
		}
		protected RequestResult CheckUserAdCampaignAccess(AdCampaign campaign, User user)
		{
			if (IsInRole(user, UserRole.Marketing) && IsUserManagerOfAdCampaign(campaign, user))
			{
				return RequestResult.AsSuccess();
			}
			else if (user.RoleModel.IsPresident || user.RoleModel.IsTopManager
				|| user.RoleModel.IsPartnerOrganigationDirector || user.RoleModel.IsPartnerOrganigationDirector
				|| user.RoleModel.HasRole(UserRole.BranchDirector))
			{
				//Причастность к департаменту и BusinessId проверяется в DepartmentFilter
				return RequestResult.AsSuccess();
			}
			return RequestResult.AsError(403, "У пользователя нет доступа к данной рекламной кампании");
		}
		protected RequestResult CheckUserAdCampaignItemAccess(AdCampaign campaign, AdCampaignItem item, User user)
		{
			if (IsInRole(user, UserRole.Marketing)
				&& (IsUserManagerOfAdCampaign(campaign, user) || IsUserWorkingOnAdCampaignItem(campaign, item, user)))
			{
				return RequestResult.AsSuccess();
			}
			else if (user.RoleModel.IsPresident || user.RoleModel.IsTopManager
				|| user.RoleModel.IsPartnerOrganigationDirector || user.RoleModel.IsPartnerOrganigationDirector
				|| user.RoleModel.HasRole(UserRole.BranchDirector))
			{
				//Причастность к департаменту и BusinessId проверяется в DepartmentFilter
				return RequestResult.AsSuccess();
			}
			return RequestResult.AsError(403, "У пользователя нет доступа к данной рекламной кампании");
		}





		protected bool IsUserManagerOfAdCampaign(AdCampaign campaign, User user)
		{
			return campaign.CampaignManagerId == user.Id;
		}
		protected bool IsUserWorkingOnAdCampaignItem(AdCampaign campaign, AdCampaignItem item, User user)
		{
			if (IsUserManagerOfAdCampaign(campaign, user)) return true;
			return item.Employees.Any(o => o.Id == user.Id);
		}
	}
}
