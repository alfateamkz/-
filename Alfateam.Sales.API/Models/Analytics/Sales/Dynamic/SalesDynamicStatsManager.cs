using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Models.Analytics.Sales.Dynamic
{
    public class SalesDynamicStatsManager
    {
        public User Manager { get; set; }



        public List<SalesDynamicStatsManagerItem> Items { get; set; } = new List<SalesDynamicStatsManagerItem>();

        public double WonOrdersSum => Items.Sum(x => x.WonOrdersSum);
        public double ConversionRate => Items.Average(x => x.ConversionRate);
        public double LostOrdersSum => Items.Sum(x => x.LostOrdersSum);
        public double LostOrdersPercent => Items.Average(x => x.LostOrdersPercent);
        public double Dynamic => Items.Sum(x => x.Dynamic);
    }
}
