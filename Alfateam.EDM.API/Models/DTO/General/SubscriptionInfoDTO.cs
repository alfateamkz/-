using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.General
{
    public class SubscriptionInfoDTO : DTOModelAbs<SubscriptionInfo>
    {
        [ForClientOnly]
        public int OutgoingDocumentsLeftCount { get; set; }
        [ForClientOnly]
        public DateTime SubscriptionBefore { get; set; }
    }
}
