using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.General
{
    public class BusinessDTO : DTOModelAbs<Business>
    {
        [ForClientOnly]
        public string Domain { get; set; }

        [ForClientOnly]
        public SubscriptionInfoDTO SubscriptionInfo { get; set; }
    }
}
