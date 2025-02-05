using Alfateam.Marketing.Models.Enums.Customers;
using Alfateam.Marketing.Models.Filters;
using Alfateam.Marketing.Models.Filters.Items.Customers;
using Alfateam.Marketing.Models.Filters.Items.Orders;
using Alfateam.Marketing.Models.Filters.Items;
using Alfateam.Website.API.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Filters.Items.Orders;
using Alfateam.Marketing.API.Models.DTO.Filters.Items;
using Alfateam.Marketing.API.Models.DTO.Filters.Items.Customers;
using Alfateam.SharedModels.DTO.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Filters
{
    public class CustomersFilterDTO : DTOModelAbs<CustomersFilter>
    {
        public DateFilterModelDTO? OrderCreatedAtPeriod { get; set; }
        public DateFilterModelDTO? CustomersWithoutOrdersAtPeriod { get; set; }
        public CustomerType CustomerType { get; set; }




        public List<OrderStatusItemDTO> OrderStatuses { get; set; } = new List<OrderStatusItemDTO>();
        public List<CustomerSourceItemDTO> CustomerSources { get; set; } = new List<CustomerSourceItemDTO>();
        public List<FilterContactTypeItemDTO> ContactTypes { get; set; } = new List<FilterContactTypeItemDTO>();
        public List<SalesFunnelStageItemDTO> SalesFunnelStages { get; set; } = new List<SalesFunnelStageItemDTO>();
        public List<SalesFunnelItemDTO> SalesFunnels { get; set; } = new List<SalesFunnelItemDTO>();



        public ByValueFilterDTO? SumOfOrder { get; set; }
        public DateFilterModelDTO? PersonBirthdayPeriod { get; set; }
    }
}
