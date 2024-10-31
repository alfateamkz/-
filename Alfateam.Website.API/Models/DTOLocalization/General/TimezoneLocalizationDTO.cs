using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.General;

namespace Alfateam.Website.API.Models.DTOLocalization.General
{
    public class TimezoneLocalizationDTO : LocalizationDTOModel<TimezoneLocalization>
    {
        public string Title { get; set; }
    }
}
