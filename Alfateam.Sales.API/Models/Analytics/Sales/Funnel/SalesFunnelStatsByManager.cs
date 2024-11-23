using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Models.Analytics.Sales.Funnel
{
    public class SalesFunnelStatsByManager
    {
        public User Manager { get; set; }

        public int OrdersCount { get; set; }
        public int LostOrdersCount { get; set; }
        public int WonOrdersCount { get; set; }


        public double OrdersSum { get; set; }
        public double LostOrdersSum { get; set; }
        public double WonOrdersSum { get; set; }



        public double ConversionRate { get; set; }
    }
}
