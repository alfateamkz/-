using Alfateam.Core.Attributes.DTO;
using Alfateam.Telephony.API.Models.DTO.General;
using Alfateam.Telephony.API.Models.DTO.HLR.Numbers.Types;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.General;
using Alfateam.Telephony.Models.HLR.Numbers.Types;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Telephony.API.Models.DTO.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<HLRNumbersToCheckDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(HLRNumbersToCheckCategoriesDTO), "HLRNumbersToCheckCategories")]
    [JsonKnownType(typeof(HLRNumbersToCheckListDTO), "HLRNumbersToCheckList")]
    public class HLRNumbersToCheckDTO : DTOModelAbs<HLRNumbersToCheck>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public HLRNumbersToCheckByCountryType CheckByCountryType { get; set; }





        [ForClientOnly]
        public List<CountryDTO> Countries { get; set; } = new List<CountryDTO>();

        [HiddenFromClient, DTOFieldBindWith("Countries", typeof(Country))]
        public List<int> CountriesIds { get; set; } = new List<int>();
    }
}
