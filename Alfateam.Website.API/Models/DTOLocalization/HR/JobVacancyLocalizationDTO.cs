using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.ContentItems;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items.HR;

namespace Alfateam.Website.API.Models.DTOLocalization.HR
{
    public class JobVacancyLocalizationDTO : LocalizationDTOModel<JobVacancyLocalization>
    {
        public string Title { get; set; }

        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public ContentDTO InnerContent { get; set; }
    }
}
