using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.Cancellation;
using Alfateam.CertificationCenter.Models.DTO.Cancellation;
using Alfateam.CertificationCenter.Models.DTO.General;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.CertificationCenter.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<CancellationRequestDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DigitalPOACancellationRequestDTO), "DigitalPOACancellationRequest")]
    [JsonKnownType(typeof(EDSCancellationRequestDTO), "EDSCancellationRequest")]
    public class CancellationRequestDTO : DTOModelAbs<CancellationRequest>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string AlfateamIDFrom { get; set; }
        public double LatitudeFrom { get; set; }
        public double LongitudeFrom { get; set; }


        public int? AlfateamIDSMSVerificationId { get; set; }
        public int? AlfateamIDEmailVerificationId { get; set; }


        public CancellationRequestInfoDTO StatusInfo { get; set; }
    }
}
