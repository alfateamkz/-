using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing
{
    /// <summary>
    /// Модель статьи бюджета рекламной кампании
    /// </summary>
    public class AdCampaignBudgetItem : AbsModel
    {

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }


        public double Sum { get; set; }


        public string Title { get; set; }
        public string? Description { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int AdCampaignItemId { get; set; }

	}
}
