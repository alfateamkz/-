
using Alfateam.Core;
using Alfateam2._0.Models.Events;

namespace Alfateam.Website.API.Abstractions
{
    public class SearchFilter
    {
        public int Offset { get; set; } = 0;
        public int Count { get; set; } = 20;
        public string Query { get; set; } = "";

        public virtual IEnumerable<T> FilterBase<T>(IEnumerable<T> items, Func<T, string> queryPredicate) where T: AbsModel
        {
            IEnumerable<T> filtered = new List<T>();
            if (!string.IsNullOrEmpty(Query))
            {
                filtered = filtered.Where(o => queryPredicate(o).Contains(Query, StringComparison.OrdinalIgnoreCase));  
            }
            return filtered.Skip(Offset).Take(Count);
        }
    }


}
