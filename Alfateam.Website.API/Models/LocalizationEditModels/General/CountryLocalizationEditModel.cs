using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.General;

namespace Alfateam.Website.API.Models.LocalizationEditModels.General
{
    public class CountryLocalizationEditModel : LocalizationEditModel<CountryLocalization>
    {
        public string Title { get; set; }
    }
}
