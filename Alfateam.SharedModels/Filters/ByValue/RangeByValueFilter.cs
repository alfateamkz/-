using Alfateam.SharedModels.Abstractions;

namespace Alfateam.SharedModels.Filters.ByValue
{
    public class RangeByValueFilter : ByValueFilter
    {
        public double From { get; set; }
        public double To { get; set; }
    }
}
