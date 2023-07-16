using Alfateam.CRM2_0.Models.Roles.Marketing.Referral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing
{
    /// <summary>
    /// Базовая модель реферальной программы
    /// </summary>
    public abstract class BaseReferralProgram : AbsModel
    {
  
        /// <summary>
        /// Минимальный лимит на вывод средств
        /// </summary>
        public double MinLimit { get; set; }


        /// <summary>
        /// Участники реферальной программы
        /// </summary>
        public List<Referral> Referrals { get; set; } = new List<Referral>();
    }
}
