using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Localization.Items;

namespace Alfateam.Website.API.Models.LocalizationEditModels
{
    public class PartnerLocalizationEditModel : LocalizationEditModel<PartnerLocalization>
    {
        public string Title { get; set; }
        public Content Content { get; set; }
    }
}
