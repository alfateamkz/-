using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class AvailabilityDTO : DTOModel<Availability>
    {
        public bool AvailableInAllCountries { get; set; } 
        public List<int> AllowedCountriesIds { get; set; } = new List<int>();
        public List<int> DisallowedCountriesIds { get; set; } = new List<int>();
    }
}
