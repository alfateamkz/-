using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Shop;

namespace Alfateam.Website.API.Filters.AdminSearch
{
    public class ShopProductSearchFilter : SearchFilter
    {
        public int? CategoryId { get; set; }

        public IEnumerable<ShopProduct> Filter(IEnumerable<ShopProduct> items)
        {
            IEnumerable<ShopProduct> filtered = new List<ShopProduct>(items);
            if (CategoryId != null)
            {
                filtered = filtered.Where(o => o.CategoryId == CategoryId);
            }

            return filtered;
            //return this.FilterBase(filtered, queryPredicate);
        }
    }
}
