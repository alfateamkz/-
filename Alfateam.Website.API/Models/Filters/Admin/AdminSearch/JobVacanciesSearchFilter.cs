using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models.Filters.Admin.AdminSearch
{
    public class JobVacanciesSearchFilter : SearchFilter
    {
        public int? CategoryId { get; set; }
        public IEnumerable<JobVacancy> Filter(IEnumerable<JobVacancy> items)
        {
            IEnumerable<JobVacancy> filtered = new List<JobVacancy>(items);
            if (CategoryId != null)
            {
                filtered = filtered.Where(o => o.CategoryId == CategoryId);
            }

            return filtered;
            //return this.FilterBase(filtered, queryPredicate);
        }
    }
}
