using Alfateam.CRM2_0.Models.Abstractions.Roles.Accountance.Transactions;
using Alfateam.CRM2_0.Models.Roles.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Accountance.Transactions
{
    /// <summary>
    /// Транзакция с привязкой к рекламной кампании
    /// </summary>
    public class MarketingTransaction : Transaction
    {
        public AdCampaign Campaign { get; set; }
        public int CampaignId { get; set; }

        public AdCampaignItem CampaignItem { get; set; }
        public int CampaignItemId { get; set; }


        public AdCampaignBudgetItem? BudgetItem { get; set; }
        public int BudgetItemId { get; set; }
    }
}
