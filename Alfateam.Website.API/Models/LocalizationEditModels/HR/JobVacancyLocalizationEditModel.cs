using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.HR;

namespace Alfateam.Website.API.Models.LocalizationEditModels.HR
{
    public class JobVacancyLocalizationEditModel : LocalizationEditModel<JobVacancyLocalization>
    {
        public string Title { get; set; }
        public Content InnerContent { get; set; }
    }
}
