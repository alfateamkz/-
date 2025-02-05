using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Referral.Items;
using Alfateam.Marketing.Models.Referral.Items;

namespace Alfateam.Marketing.API.Models.DTO.Referral
{
    public class MLMNetworkReferralProgramDTO : ReferralProgramDTO
    {
        public List<MLMNetworkReferralProgramLevelDTO> Levels { get; set; } = new List<MLMNetworkReferralProgramLevelDTO>();
    }
}
