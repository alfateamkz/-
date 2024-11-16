using Alfateam.Sales.API.Abstractions;

namespace Alfateam.Sales.API.Models.DatePeriod
{
    public class MonthDateFilterModel : DateFilterModel
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public override DateFilterPeriod GetPeriod()
        {
            var date = new DateTime(Year, Month, 1);
            return new DateFilterPeriod
            {
                From = date,
                To = date.AddMonths(1).AddSeconds(-1)
            };
        }
    }
}
