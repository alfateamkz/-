using Alfateam.Sales.Models.Abstractions;

namespace Alfateam.Sales.API.Models.Analytics.Sales.Plan
{
    public class SalesPlanStatsItem
    {
        public SalesPlan Plan { get; set; }

        public double LeftToComplete { get; set; }
        public double CompletionPercent { get; set; }
    }
}
