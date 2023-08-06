using Alfateam.Website.API.Models.ClientModels.HR;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models
{
    public class JobVacancyCard
    {
        public JobVacancyClientModel Vacancy { get; set; }
        public int WatchingNow { get; set; }
    }
}
