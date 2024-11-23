namespace Alfateam.Sales.API.Models.Analytics.Sales.Dynamic
{
    public class SalesDynamicStatsManagerItem
    {
        public bool IsSecondary { get; set; }
        public double WonOrdersSum { get; set; }
        public double ConversionRate { get; set; }
        public double LostOrdersSum { get; set; }
        public double LostOrdersPercent { get; set; }
        public double Dynamic { get; set; }
    }
}
