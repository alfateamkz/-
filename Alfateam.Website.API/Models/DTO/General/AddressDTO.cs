using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class AddressDTO : DTOModel<Address>
    {
        [ForClientOnly]
        public CountryDTO Country { get; set; }
        public int CountryId { get; set; }


        public string State { get; set; }
        public string? District { get; set; }


        public string City { get; set; }

        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string PostalCode { get; set; }
    }
}
