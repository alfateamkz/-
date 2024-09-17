using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.HR;

namespace Alfateam.Website.API.Models.DTOLocalization.HR
{
    public class JobVacancyLocalizationDTO : LocalizationDTOModel<JobVacancyLocalization>
    {
        public string Title { get; set; }
        public Content InnerContent { get; set; }
    }
}
