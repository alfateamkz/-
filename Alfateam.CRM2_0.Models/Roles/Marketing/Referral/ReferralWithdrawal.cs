using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing.Referral
{
    /// <summary>
    /// Модель вывода средств по реферальной программе
    /// </summary>
    public class ReferralWithdrawal : AbsModel
    {
        public double Sum { get; set; }
    }
}
