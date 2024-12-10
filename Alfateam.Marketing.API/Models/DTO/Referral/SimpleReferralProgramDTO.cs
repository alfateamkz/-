using Alfateam.CRM2_0.Models.Roles.Marketing.Referral.Programs;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Referral
{
    public class SimpleReferralProgramDTO : ReferralProgramDTO
    { 
        public double Percent { get; set; }
    }
}
