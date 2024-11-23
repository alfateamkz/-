using Alfateam.DB.ServicesDBs;
using Alfateam.Sales.API.Helpers;
using Alfateam.Sales.Models.Enums.Statuses;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Sales.Models.General;
using Alfateam.Sales.Models.Orders;

namespace Alfateam.Sales.API.Models.Analytics.Sales.Funnel
{
    public class SalesFunnelStats
    {
        public List<SalesFunnelStatsStage> Stages { get; set; } = new List<SalesFunnelStatsStage>();
        public double OrdersSum => Stages.Sum(o => o.OrdersSum);
        public double LostOrdersSum => Stages.Where(o => o.Stage.Status == SalesFunnelStageStatus.OrderLost).Sum(o => o.OrdersSum);
        public double WonOrdersSum => Stages.Where(o => o.Stage.Status == SalesFunnelStageStatus.OrderClosed).Sum(o => o.OrdersSum);
        public double ConversionRate => Stages.Where(o => o.Stage.Status == SalesFunnelStageStatus.OrderClosed).Sum(o => o.OrdersCount) / Stages.Sum(o => o.OrdersCount) * 100;




        public List<SalesFunnelStatsByManager> ByManagers { get; set; } = new List<SalesFunnelStatsByManager>();
        public int ByManagersOrdersCount => ByManagers.Sum(o => o.OrdersCount);
        public int ByManagersLostOrdersCount => ByManagers.Sum(o => o.LostOrdersCount);
        public int ByManagersWonOrdersCount => ByManagers.Sum(o => o.WonOrdersCount);


        public double ByManagersOrdersSum => ByManagers.Sum(o => o.OrdersSum);
        public double ByManagersLostOrdersSum => ByManagers.Sum(o => o.LostOrdersSum);
        public double ByManagersWonOrdersSum => ByManagers.Sum(o => o.WonOrdersSum);

        public double ByManagersConversionRate => ByManagers.Sum(o => o.ConversionRate);

        public SalesFunnelStats Fill(CurrencyRatesDbContext currencyDB, 
                                     Currency mainCurrency, 
                                     SalesFunnel funnel, 
                                     IEnumerable<User> managers,
                                     IEnumerable<Order> orders)
        {
            orders = orders.Where(o => o.SaleInfo.FunnelId == funnel.Id);
            foreach(var stage in funnel.Stages)
            {
                var ordersByStage = orders.Where(o => o.SaleInfo.FunnelStageId == stage.Id);

                Stages.Add(new SalesFunnelStatsStage
                {
                    Stage = stage,
                    ConversionRate = 0, //TODO: SalesFunnelStats.ConversionRate
                    OrdersCount = ordersByStage.Count(),
                    OrdersSum = ConversionHelper.GetOrdersSum(currencyDB, mainCurrency, ordersByStage)
                });
            }

            foreach(var manager in managers)
            {
                var managerOrders = orders.Where(o => o.SaleInfo.ResponsibleId == manager.Id);

                var lostOrders = managerOrders.Where(o => o.SaleInfo.FunnelStage.Status == SalesFunnelStageStatus.OrderLost);
                var wonOrders = managerOrders.Where(o => o.SaleInfo.FunnelStage.Status == SalesFunnelStageStatus.OrderClosed);

                ByManagers.Add(new SalesFunnelStatsByManager
                {
                    Manager = manager,
                    LostOrdersCount = lostOrders.Count(),
                    LostOrdersSum = ConversionHelper.GetOrdersSum(currencyDB, mainCurrency, lostOrders),
                    WonOrdersCount = wonOrders.Count(),
                    WonOrdersSum = ConversionHelper.GetOrdersSum(currencyDB, mainCurrency, wonOrders),
                    OrdersCount = managerOrders.Count(),
                    OrdersSum = ConversionHelper.GetOrdersSum(currencyDB, mainCurrency, managerOrders),
                    ConversionRate = wonOrders.Count() / managerOrders.Count() * 100
                });
            }

            return this;
        }

    }
}
