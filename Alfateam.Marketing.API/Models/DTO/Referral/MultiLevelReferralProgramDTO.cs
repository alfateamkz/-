using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Referral.Items;
using Alfateam.Marketing.Models.Enums;

namespace Alfateam.Marketing.API.Models.DTO.Referral
{
    public class MultiLevelReferralProgramDTO : ReferralProgramDTO
    {
        public ReferralProgramTresholdType MetricType { get; set; }
        public List<MultiLevelReferralProgramLevelDTO> Levels { get; set; } = new List<MultiLevelReferralProgramLevelDTO>();
    }
}
