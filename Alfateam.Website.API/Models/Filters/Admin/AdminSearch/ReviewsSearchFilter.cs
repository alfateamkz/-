using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Reviews;

namespace Alfateam.Website.API.Models.Filters.Admin.AdminSearch
{
    public class ReviewsSearchFilter : SearchFilter
    {
        public bool ShowOnlyHidden { get; set; }

        public IEnumerable<Review> Filter(IEnumerable<Review> items, Func<Review, string> queryPredicate)
        {
            IEnumerable<Review> filtered = new List<Review>(items);
            if (ShowOnlyHidden)
            {
                filtered = filtered.Where(o => o.IsHidden == true);
            }
            return this.FilterBase(filtered, queryPredicate);
        }
    }
}
