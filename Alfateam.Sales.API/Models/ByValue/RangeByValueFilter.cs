using Alfateam.Sales.API.Abstractions;

namespace Alfateam.Sales.API.Models.ByValue
{
    public class RangeByValueFilter : ByValueFilter
    {
        public double From { get; set; }
        public double To { get; set; }
    }
}
