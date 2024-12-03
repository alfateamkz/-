using Alfateam.SharedModels.Abstractions;
using Alfateam.SharedModels.Filters.Dates.Props;


namespace Alfateam.SharedModels.Filters.Dates
{
    public class YearDateFilterModel : DateFilterModel
    {
        public int Year { get; set; }

        public override DateFilterPeriod GetPeriod()
        {
            var date = new DateTime(Year, 1, 1);
            return new DateFilterPeriod
            {
                From = date,
                To = date.AddYears(1).AddSeconds(-1)
            };
        }
    }
}
