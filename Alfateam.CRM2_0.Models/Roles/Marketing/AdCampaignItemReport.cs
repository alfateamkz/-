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
    /// Модель отчета выполненных работ по рекламной кампании
    /// </summary>
    public class AdCampaignItemReport : AbsModel
    {
        public User CreatedBy { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
