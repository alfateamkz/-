using Alfateam.Website.API.Models.DTO.HR;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models
{
    public class JobVacancyCard
    {
        public JobVacancyDTO Vacancy { get; set; }
        public int WatchingNow { get; set; }
    }
}
