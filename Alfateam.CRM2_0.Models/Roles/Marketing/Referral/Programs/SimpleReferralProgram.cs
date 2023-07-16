using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing.Referral.Programs
{
    /// <summary>
    /// Модель одноуровневой реферальной программы
    /// </summary>
    public class SimpleReferralProgram : BaseReferralProgram
    {
        /// <summary>
        /// Процент по реферальной программе
        /// </summary>
        public double Percent { get; set; }
    }
}
