using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Marketing.Referral
{
    /// <summary>
    /// Модель реферала
    /// </summary>
    public class Referral : AbsModel
    {
        /// <summary>
        /// Пользователь в CRM системе 
        /// </summary>
        public User Owner { get; set; }


        /// <summary>
        /// Текущий баланс
        /// </summary>
        public double Balance { get; set; }


        /// <summary>
        /// Привлеченные рефералы
        /// </summary>
        public List<Referral> Referrals { get; set; } = new List<Referral>();






        /// <summary>
        /// Поступления по реферальной программе
        /// </summary>
        public List<ReferralEntry> Entries { get; set; } = new List<ReferralEntry>();

        /// <summary>
        /// История выплат по реферальной программе
        /// </summary>
        public List<ReferralWithdrawal> Withdrawals { get; set; } = new List<ReferralWithdrawal>();




        
    }
}
