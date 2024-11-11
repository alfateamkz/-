using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Shop.Orders;

namespace Alfateam.Website.API.Models.Filters.Admin.AdminSearch
{
    public class ShopOrdersSearchFilter : SearchFilter
    {
        public ShopOrderStatus? Status { get; set; }
        public IEnumerable<ShopOrder> Filter(IEnumerable<ShopOrder> items)
        {
            IEnumerable<ShopOrder> filtered = new List<ShopOrder>(items);
            if (Status != null)
            {
                filtered = filtered.Where(o => o.Status == Status);
            }
            if (!string.IsNullOrEmpty(Query))
            {
                filtered = filtered.Where(o => o.Items.Any(o => o.Item.Title.Contains(Query, StringComparison.OrdinalIgnoreCase)));
            }

            return this.FilterBase(filtered);
        }
    }
}
