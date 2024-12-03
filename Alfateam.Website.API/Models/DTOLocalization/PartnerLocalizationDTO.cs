using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.DTO.ContentItems;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items;

namespace Alfateam.Website.API.Models.DTOLocalization
{
    public class PartnerLocalizationDTO : LocalizationDTOModel<PartnerLocalization>
    {
        public string Title { get; set; }
        public ContentDTO Content { get; set; }
    }
}
