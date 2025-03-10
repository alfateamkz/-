﻿using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing.Tasks;

namespace Alfateam.CRM2_0.Models.ClientModels.Abstractions.Roles.Marketing
{
	public abstract class BaseAdCampaignItemTaskClientModel : ClientModel<BaseAdCampaignItemTask>
	{
		public string Title { get; set; }
		public string? Description { get; set; }


		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public AdCampaignItemTaskStatus Status { get; set; }




		public List<BaseAdCampaignItemTaskClientModel> SubTasks { get; set; } = new List<BaseAdCampaignItemTaskClientModel>();
	}
}
