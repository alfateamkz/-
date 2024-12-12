using Alfateam.Marketing.API.Abstractions;

namespace Alfateam.Marketing.API.Models.SearchFilters.Referral
{
    public class ReferralUsersSearchFilter : SearchFilter
    {
        public int ReferralProgramId { get; set; }
        public bool? ShowBanned { get; set; }
    }
}
