using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Localization.General;

namespace Alfateam.Website.API.Models.DTOLocalization.General
{
    public class CountryLocalizationDTO : DTOModel<CountryLocalization>
    {
        public string Title { get; set; }
    }
}
