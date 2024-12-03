using Alfateam.SharedModels.Abstractions;
using Alfateam.SharedModels.Enums;


namespace Alfateam.SharedModels.Filters.ByValue
{
    public class ConditionalByValueFilter : ByValueFilter
    {
        public ConditionalByValueFilterType Type { get; set; }
        public double Value { get; set; }
    }
}
