using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Staff;
using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing
{
    /// <summary>
    /// Пункт рекламной кампании
    /// </summary>
    public class AdCampaignItem : AbsModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AdCampaignItemStatus Status { get; set; } = AdCampaignItemStatus.Planned;


        public string Title { get; set; }
        public string? Description { get; set; }
        public AdCampaignChannel Channel { get; set; }
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<AdCampaignBudgetItem> BudgetItems { get; set; } = new List<AdCampaignBudgetItem>();




        public List<BaseAdCampaignItemTask> Tasks { get; set; } = new List<BaseAdCampaignItemTask>();




        public List<Worker> Employees { get; set; } = new List<Worker>();
        public List<AdCampaignItemReport> Reports { get; set; } = new List<AdCampaignItemReport>();


    }
}
