namespace Alfateam.Sales.API.Models.Analytics.Sales.Compare
{
    public class SalesCompareStatsItem
    {
        public DateTime CurrentPeriodDate { get; set; }
        public DateTime PreviousPeriodDate { get; set; }


        public double CurrentPeriodWonOrdersSum { get; set; }
        public double PreviousPeriodWonOrdersSum { get; set; }
        public double WonOrdersSumPeriodsDifference => CurrentPeriodWonOrdersSum - PreviousPeriodWonOrdersSum;
    }
}
