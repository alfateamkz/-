using Alfateam.Marketing.API.Models.DTO.Referral.Main;

namespace Alfateam.Marketing.API.Models.Referral
{
    public class ReferralUserStats
    {
        public ReferralUserDTO User { get; set; }

        public int ReferralsCount { get; set; }
        public int OrdersCount { get; set; }


        public double EarnedSum { get; set; }
        public double SumOnAccounts { get; set; }
        public double SumOnWithdrawal { get; set; }
    }
}
