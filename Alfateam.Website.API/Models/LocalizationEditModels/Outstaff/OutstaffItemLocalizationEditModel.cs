using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Outstaff;

namespace Alfateam.Website.API.Models.LocalizationEditModels.Outstaff
{
    public class OutstaffItemLocalizationEditModel : LocalizationEditModel<OutstaffItemLocalization>
    {
        public string Title { get; set; }
    }
}
