using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Portfolios;

namespace Alfateam.Website.API.Filters.AdminSearch
{
    public class PortfoliosSearchFilter : SearchFilter
    {
        public int? CategoryId { get; set; }
        public int? IndustryId { get; set; }

        public IEnumerable<Portfolio> Filter(IEnumerable<Portfolio> items, Func<Portfolio, string> queryPredicate)
        {
            IEnumerable<Portfolio> filtered = new List<Portfolio>(items);
            if (CategoryId != null)
            {
                filtered = filtered.Where(o => o.CategoryId == CategoryId);
            }
            if (IndustryId != null)
            {
                filtered = filtered.Where(o => o.IndustryId == IndustryId);
            }
            return this.FilterBase(filtered, queryPredicate);
        }
    }
}
