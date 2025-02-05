using Alfateam.Telephony.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General
{
    public class SubscriptionInfoDTO : DTOModelAbs<SubscriptionInfo>
    {
        public DateTime SubscriptionBefore { get; set; }
    }
}
