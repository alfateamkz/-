using Alfateam.SharedModels.Abstractions;
using Alfateam.SharedModels.Filters.Dates.Props;

namespace Alfateam.SharedModels.Filters.Dates
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
