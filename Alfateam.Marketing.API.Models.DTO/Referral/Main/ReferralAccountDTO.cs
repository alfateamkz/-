using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Referral.Main;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Referral.Main
{
    public class ReferralAccountDTO : DTOModelAbs<ReferralAccount>
    {
        [ForClientOnly]
        public string CurrencyCode { get; set; }
    }
}
