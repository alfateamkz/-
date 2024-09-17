using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.Outstaff;

namespace Alfateam.Website.API.Models.DTOLocalization.Outstaff
{
    public class OutstaffItemLocalizationDTO : LocalizationDTOModel<OutstaffItemLocalization>
    {
        public string Title { get; set; }
    }
}
