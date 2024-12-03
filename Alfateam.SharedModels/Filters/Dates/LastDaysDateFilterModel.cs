using Alfateam.SharedModels.Abstractions;
using Alfateam.SharedModels.Filters.Dates.Props;


namespace Alfateam.SharedModels.Filters.Dates
{
    public class LastDaysDateFilterModel : DateFilterModel
    {
        public int Days { get; set; }

        public override DateFilterPeriod GetPeriod()
        {
            return new DateFilterPeriod
            {
                To = DateTime.UtcNow.Date,
                From = DateTime.UtcNow.Date.AddDays(-Days),
            };
        }
    }
}
