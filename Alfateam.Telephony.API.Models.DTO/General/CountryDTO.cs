using Alfateam.Telephony.Models.General;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Telephony.API.Models.DTO.General
{
    public class CountryDTO : DTOModelAbs<Country>
    {
        public string Title { get; set; }
        public string CountryCode { get; set; }
    }
}
