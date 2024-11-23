namespace Alfateam.Sales.API.Models.Analytics.Sales.Plan
{
    public class SalesPlanStats
    {
        public double WonOrdersSum { get; set; }
        public List<SalesPlanStatsItem> Plans { get; set; } = new List<SalesPlanStatsItem>();
    }
}
