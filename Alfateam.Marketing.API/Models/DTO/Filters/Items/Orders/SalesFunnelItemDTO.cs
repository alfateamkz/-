using Alfateam.Marketing.Models.Filters.Items.Orders;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Filters.Items.Orders
{
    public class SalesFunnelItemDTO : DTOModelAbs<SalesFunnelItem>
    {
        public int CRM_FunnelId { get; set; }
    }
}
