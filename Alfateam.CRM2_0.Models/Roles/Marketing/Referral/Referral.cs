using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.Accountance;
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
		public int OwnerId { get; set; }




        /// <summary>
        /// Привлеченные рефералы
        /// </summary>
        public List<Referral> Referrals { get; set; } = new List<Referral>();



        /// <summary>
        /// Реферальные валютные счета 
        /// </summary>
        public List<Account> Accounts { get; set; } = new List<Account>();

        



        public BaseReferralProgram BaseReferralProgram { get; set; }
		public int BaseReferralProgramId { get; set; }
	}
}
