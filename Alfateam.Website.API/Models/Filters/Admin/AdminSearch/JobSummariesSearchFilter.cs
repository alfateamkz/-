using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models.Filters.Admin.AdminSearch
{
    public class JobSummariesSearchFilter : SearchFilter
    {
        public JobSummaryStatus? Status { get; set; }
        public IEnumerable<JobSummary> Filter(IEnumerable<JobSummary> items)
        {
            IEnumerable<JobSummary> filtered = new List<JobSummary>(items);
            if (Status != null)
            {
                filtered = filtered.Where(o => o.Status == Status);
            }

            return filtered;
            //return this.FilterBase(filtered, queryPredicate);
        }
    }
}
