using Alfateam.Sales.API.Abstractions;

namespace Alfateam.Sales.API.Models.DatePeriod
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
