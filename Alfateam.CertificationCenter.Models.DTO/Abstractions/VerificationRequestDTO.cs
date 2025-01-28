using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.DTO.General;
using Alfateam.CertificationCenter.Models.DTO.Verification;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.Verification;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<IssueRequestDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(PersonalVerificationRequestDTO), "PersonalVerificationRequest")]
    public class VerificationRequestDTO : DTOModelAbs<VerificationRequest>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public double LatitudeFrom { get; set; }
        public double LongitudeFrom { get; set; }


        public VerificationRequestInfoDTO StatusInfo { get; set; }
    }
}
