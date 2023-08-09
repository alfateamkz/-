using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.General;

namespace Alfateam.Website.API.Models.LocalizationEditModels.General
{
    public class LanguageLocalizationEditModel : LocalizationEditModel<LanguageLocalization>
    {
        public string Title { get; set; }
    }
}
