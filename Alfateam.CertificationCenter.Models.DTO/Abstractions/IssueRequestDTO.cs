using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.DTO.General;
using Alfateam.CertificationCenter.Models.DTO.IssueRequests;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.IssueRequests;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.CertificationCenter.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<IssueRequest>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DigitalPOAIssueRequestDTO), "DigitalPOAIssueRequest")]
    [JsonKnownType(typeof(EDSIssueRequestDTO), "EDSIssueRequest")]
    public class IssueRequestDTO : DTOModelAbs<IssueRequest>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [ForClientOnly]
        public string AlfateamIDFrom { get; set; }
        public double LatitudeFrom { get; set; }
        public double LongitudeFrom { get; set; }


        [ForClientOnly]
        public IssueRequestInfoDTO StatusInfo { get; set; }
    }
}
