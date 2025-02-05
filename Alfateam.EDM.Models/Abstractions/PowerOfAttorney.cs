using Alfateam.Core;
using Alfateam.EDM.Models.Documents.DocumentSigning.ApproveStrategies;
using Alfateam.EDM.Models.General;
using Alfateam.EDM.Models.General.PowersOfAttorney;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{
    /// <summary>
    /// Абстрактная модель доверенности на подписание документов для сотрудников
    /// </summary>
    [JsonConverter(typeof(JsonKnownTypesConverter<PowerOfAttorney>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DigitalPowerOfAttorney), "DigitalPowerOfAttorney")]
    [JsonKnownType(typeof(NotarizedPowerOfAttorney), "NotarizedPowerOfAttorney")]
    public class PowerOfAttorney : AbsModel
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
        public PowerOfAttorneyVerificationInfo VerificationInfo { get; set; }


        /// <summary>
        /// К кому прикреплена доверенность
        /// </summary>
        public int? UserId { get; set; }
    }
}
