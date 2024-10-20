using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.General.PowersOfAttorney;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General.PowersOfAttorney;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

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


        /// <summary>
        /// Полномочия текстом
        /// </summary>
        public string TextOfPower { get; set; }




        /// <summary>
        /// Проверена ли доверенность администрацией сервиса
        /// </summary>
        [ForClientOnly]
        public bool IsVerified { get; set; }
    }
}
