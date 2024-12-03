using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Enums.Customers;
using Alfateam.Marketing.Models.Filters.Items;
using Alfateam.Marketing.Models.Filters.Items.Customers;
using Alfateam.Marketing.Models.Filters.Items.Orders;
using Alfateam.SharedModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Filters
{
    public class CustomersFilter : AbsModel
    {
        public DateFilterModel? OrderCreatedAtPeriod { get; set; }
        public DateFilterModel? CustomersWithoutOrdersAtPeriod { get; set; }
        public CustomerType CustomerType { get; set; }




        public List<OrderStatusItem> OrderStatuses { get; set; } = new List<OrderStatusItem>();
        public List<CustomerSourceItem> CustomerSources { get; set; } = new List<CustomerSourceItem>();
        public List<FilterContactTypeItem> ContactTypes { get; set; } = new List<FilterContactTypeItem>();
        public List<SalesFunnelStageItem> SalesFunnelStages { get; set; } = new List<SalesFunnelStageItem>();
        public List<SalesFunnelItem> SalesFunnels { get; set; } = new List<SalesFunnelItem>();



        public ByValueFilter? SumOfOrder { get; set; }
        public DateFilterModel? PersonBirthdayPeriod { get; set; }
    }
}
