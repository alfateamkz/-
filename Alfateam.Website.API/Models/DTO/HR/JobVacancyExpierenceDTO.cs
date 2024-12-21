using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models.DTO.HR
{
    public class JobVacancyExpierenceDTO : DTOModel<JobVacancyExpierence>
    {
        public int? YearsFrom { get; set; }
        public int? YearsTo { get; set; }
    }
}
