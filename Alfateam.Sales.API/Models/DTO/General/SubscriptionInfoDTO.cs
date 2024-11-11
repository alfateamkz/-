using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.General
{
    public class SubscriptionInfoDTO : DTOModelAbs<SubscriptionInfo>
    {
        public DateTime SubscriptionBefore { get; set; }
    }
}
