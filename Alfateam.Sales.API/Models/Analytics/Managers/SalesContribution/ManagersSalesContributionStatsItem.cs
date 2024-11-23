using Alfateam.Sales.Models.General;

namespace Alfateam.Sales.API.Models.Analytics.Managers.SalesContribution
{
    public class ManagersSalesContributionStatsItem
    {
        public User Manager { get; set; }

        public double SumOfOrdersInWork { get; set; }

        public double SumOfWonOrders { get; set; }
        public double AverageOfWonOrders { get; set; }

        public double ConversionRate { get; set; }

    }
}
