using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.HR;

namespace Alfateam.Website.API.Models.DTO.HR
{
    public class JobVacancyDTO : AvailabilityDTOModel<JobVacancy>
    {
        public string Title { get; set; }
        public Content InnerContent { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);



        [ForClientOnly]
        public CurrencyDTO Currency { get; set; }
        public int CurrencyId { get; set; }



        public double? SalaryFrom { get; set; }
        public double? SalaryTo { get; set; }


        public JobVacancyExpierence Expierence { get; set; }

        public int MainLanguageId { get; set; }
    }
}
