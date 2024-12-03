using Alfateam.SharedModels.Abstractions;
using Alfateam.SharedModels.Filters.Dates.Props;


namespace Alfateam.SharedModels.Filters.Dates
{
    public class PeriodDateFilterModel : DateFilterModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public override DateFilterPeriod GetPeriod()
        {
            return new DateFilterPeriod
            {
                From = From,
                To = To
            };
        }
    }
}
