using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.API.Models.DTO.General;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.ExternalInteractions.Items.Callback;
using Alfateam.Telephony.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.ExternalInteractions.Items.Callback
{
    public class CallbackCountriesFilterDTO : DTOModelAbs<CallbackCountriesFilter>
    {
        public CallbackCountriesFilterType Type { get; set; }



        [ForClientOnly]
        public List<CountryDTO> CountriesExcept { get; set; } = new List<CountryDTO>();

        [DTOFieldBindWith(typeof(Country))]
        public List<int> CountriesExceptIds { get; set; } = new List<int>();
    }
}
