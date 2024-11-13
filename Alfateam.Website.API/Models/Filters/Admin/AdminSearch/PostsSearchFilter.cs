using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Portfolios;
using Alfateam2._0.Models.Posts;

namespace Alfateam.Website.API.Filters.AdminSearch
{
    public class PostsSearchFilter : SearchFilter
    {
        public int? CategoryId { get; set; }
        public int? IndustryId { get; set; }

        public IEnumerable<Post> Filter(IEnumerable<Post> items)
        {
            IEnumerable<Post> filtered = new List<Post>(items);
            if (CategoryId != null)
            {
                filtered = filtered.Where(o => o.CategoryId == CategoryId);
            }
            if (IndustryId != null)
            {
                filtered = filtered.Where(o => o.IndustryId == IndustryId);
            }
            return filtered;
            //return this.FilterBase(filtered, queryPredicate);
        }
    }
}
