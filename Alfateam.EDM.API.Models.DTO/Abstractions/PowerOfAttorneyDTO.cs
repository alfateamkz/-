using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.API.Models.DTO.General.PowersOfAttorney;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General;
using Alfateam.EDM.Models.General.PowersOfAttorney;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Alfateam.EDM.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<PowerOfAttorneyDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DigitalPowerOfAttorneyDTO), "DigitalPowerOfAttorney")]
    [JsonKnownType(typeof(NotarizedPowerOfAttorneyDTO), "NotarizedPowerOfAttorney")]
    public class PowerOfAttorneyDTO : DTOModelAbs<PowerOfAttorney>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Number { get; set; }
        public DateTime GivenAt { get; set; }
        public DateTime ValidBefore { get; set; }



        public string PrincipalCountryCode { get; set; }
        public string PrincipalBusinessNumber { get; set; }


        public string ConfidantCountryCode { get; set; }
        public string ConfidantBusinessNumber { get; set; }


        [Description("Полномочия текстом")]
        public string TextOfPower { get; set; }




        [ForClientOnly]
        public PowerOfAttorneyVerificationInfoDTO VerificationInfo { get; set; }
    }
}
