using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Referral
{
    public class SimpleReferralProgramDTO : ReferralProgramDTO
    { 
        public double Percent { get; set; }
    }
}
