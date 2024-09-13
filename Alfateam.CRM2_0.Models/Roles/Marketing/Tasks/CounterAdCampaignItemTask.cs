using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing.Tasks
{
    /// <summary>
    /// Модель задачи пункта рекламной кампании с счетчиком выполнения
    /// </summary>
    public class CounterAdCampaignItemTask : BaseAdCampaignItemTask
    {
        public double Total { get; set; }
        public double Completed { get; set; }   
    }
}
