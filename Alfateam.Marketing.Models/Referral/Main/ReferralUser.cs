using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Referral.Main
{
    public class ReferralUser : AbsModel
    {

        public string AlfateamID { get; set; }


        /// <summary>
        /// Рефералы реферала
        /// </summary>
        public List<ReferralUser> Referrals { get; set; } = new List<ReferralUser>();

        /// <summary>
        /// Счета реферала
        /// </summary>
        public List<ReferralAccount> Accounts { get; set; } = new List<ReferralAccount>();


        /// <summary>
        /// Информация о бане реферала, если он забанен
        /// </summary>
        public ReferralBanInfo? BanInfo { get; set; }
        public int? BanInfoId { get; set; }





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ReferralProgramId { get; set; }
    }
}
