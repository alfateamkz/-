using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing.Referral
{
    /// <summary>
    /// Модель уровня многоуровневой реферальной программы
    /// </summary>
    public class MultiLevelReferralProgramLevel : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public double Percent { get; set; }



        public int MultiLevelReferralProgramId { get; set; }

	}
}
