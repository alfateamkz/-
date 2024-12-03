using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.HR;
using Alfateam.Website.API.Models.DTO.ContentItems;

namespace Alfateam.Website.API.Models.DTO.HR
{
    public class JobVacancyDTO : AvailabilityDTOModel<JobVacancy>
    {
        public string Title { get; set; }
        public ContentDTO InnerContent { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);



        [ForClientOnly]
        public CurrencyDTO Currency { get; set; }
        public int CurrencyId { get; set; }



        public double? SalaryFrom { get; set; }
        public double? SalaryTo { get; set; }


        public JobVacancyCategoryDTO? Category { get; set; }
        public int? CategoryId { get; set; }


        public JobVacancyExpierence Expierence { get; set; }

       
    }
}
