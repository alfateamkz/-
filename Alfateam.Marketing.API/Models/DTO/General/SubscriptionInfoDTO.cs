using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.General
{
    public class SubscriptionInfoDTO : DTOModelAbs<SubscriptionInfo>
    {
        [ForClientOnly]
        public DateTime SubscriptionBefore { get; set; }

    }
}
