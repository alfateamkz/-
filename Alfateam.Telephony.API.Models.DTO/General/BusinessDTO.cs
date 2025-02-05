using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General
{
    public class BusinessDTO : DTOModelAbs<Business>
    {
        [ForClientOnly]
        public string Domain { get; set; }

        [ForClientOnly]
        public SubscriptionInfo SubscriptionInfo { get; set; }
    }
}
