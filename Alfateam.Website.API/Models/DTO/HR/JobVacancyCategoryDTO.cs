using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models.DTO.HR
{
    public class JobVacancyCategoryDTO : DTOModel<JobVacancyCategory>
    {
        public string Title { get; set; }
    }
}
