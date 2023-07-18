using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing
{
    /// <summary>
    /// Модель рекламной кампании
    /// </summary>
    public class AdCampaign : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public User CampaignManager { get; set; }
        public AdCampaignStatus Status { get; set; } = AdCampaignStatus.Planned;



        public List<AdCampaignItem> CampaignItems { get; set; } = new List<AdCampaignItem>();
       
    }
}
