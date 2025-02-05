using Alfateam.Marketing.Models.Filters.Items.Orders;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Filters.Items.Orders
{
    public class SalesFunnelStageItemDTO : DTOModelAbs<SalesFunnelStageItem>
    {
        public int CRM_FunnelId { get; set; }
        public int CRM_FunnelStageId { get; set; }
    }
}
