using Alfateam.SharedModels.Abstractions;
using Alfateam.SharedModels.Filters.Dates.Props;


namespace Alfateam.SharedModels.Filters.Dates
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
