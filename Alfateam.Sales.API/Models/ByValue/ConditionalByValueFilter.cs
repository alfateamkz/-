using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Enums;

namespace Alfateam.Sales.API.Models.ByValue
{
    public class ConditionalByValueFilter : ByValueFilter
    {
        public ConditionalByValueFilterType Type { get; set; }
        public double Value { get; set; }
    }
}
