using Alfateam.Marketing.Models.Referral.Main;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Referral.Main
{
    public class ReferralBanInfoDTO : DTOModelAbs<ReferralBanInfo>
    {
        public DateTime BannedBefore { get; set; }
        public string? BanReason { get; set; }
    }
}
