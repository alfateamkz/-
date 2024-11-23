using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.Customers;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.Customers;
using Alfateam.Sales.Models.General;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<AbsCanBeCustomerDTO<AbsCanBeCustomer>>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CompanyDTO), "Company")]
    [JsonKnownType(typeof(PersonContactDTO), "PersonContact")]
    public class AbsCanBeCustomerDTO<T> : DTOModelAbs<T> where T : AbsCanBeCustomer, new()
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public List<ContactInfoDTO> Contacts { get; set; } = new List<ContactInfoDTO>();
        public string? Comment { get; set; }



        [ForClientOnly]
        public UserDTO CreatedBy { get; set; }
    }
}
