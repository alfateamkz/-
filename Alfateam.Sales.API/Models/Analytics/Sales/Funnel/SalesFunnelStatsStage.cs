using Alfateam.Sales.API.Models.DTO.Funnel;
using Alfateam.Sales.Models.Funnel;

namespace Alfateam.Sales.API.Models.Analytics.Sales.Funnel
{
    public class SalesFunnelStatsStage 
    {
        public SalesFunnelStage Stage { get; set; }

        public int OrdersCount { get; set; }
        public double OrdersSum { get; set; }
        public double ConversionRate { get; set; }
    }
}
