using Alfateam.Marketing.API.Abstractions;

namespace Alfateam.Marketing.API.Models.SearchFilters.Referral
{
    public class RefUserAccountsSearchFilter : SearchFilter
    {
        public int ReferralProgramId { get; set; }
        public int UserId { get; set; }



        public bool HideZeroBalancedAccounts { get; set; }
    }
}
