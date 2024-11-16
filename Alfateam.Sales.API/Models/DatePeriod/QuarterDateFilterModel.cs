using Alfateam.Sales.API.Abstractions;

namespace Alfateam.Sales.API.Models.DatePeriod
{
    public class QuarterDateFilterModel : DateFilterModel
    {
        public int Year { get; set; }
        public int Quarter { get; set; }

        public override DateFilterPeriod GetPeriod()
        {
            var month = Quarter + ((Quarter - 1) * 3);
            var date = new DateTime(Year, month, 1);
            return new DateFilterPeriod
            {
                From = date,
                To = date.AddMonths(3).AddSeconds(-1)
            };
        }
    }
}
