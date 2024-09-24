using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class AvailabilityDTO : DTOModel<Availability>
    {
        public bool AvailableInAllCountries { get; set; }


        [DTOFieldBindWith(typeof(Country))]
        public List<int> AllowedCountriesIds { get; set; } = new List<int>();

        [DTOFieldBindWith(typeof(Country))]
        public List<int> DisallowedCountriesIds { get; set; } = new List<int>();
    }
}
