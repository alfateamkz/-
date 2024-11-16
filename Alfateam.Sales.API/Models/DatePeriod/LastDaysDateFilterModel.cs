using Alfateam.Sales.API.Abstractions;

namespace Alfateam.Sales.API.Models.DatePeriod
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
