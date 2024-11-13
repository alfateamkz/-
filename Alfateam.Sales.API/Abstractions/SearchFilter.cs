using Alfateam.Core;

namespace Alfateam.Sales.API.Abstractions
{
    public class SearchFilter
    {
        public int Offset { get; set; } = 0;
        public int Count { get; set; } = 20;

        public string Query { get; set; }

        //public virtual IEnumerable<T> FilterBase<T>(IEnumerable<T> items) where T : AbsModel
        //{
        //    return items.Skip(Offset).Take(Count);
        //}

    }
}
