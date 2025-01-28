using Alfateam.CertificationCenter.Models.Abstraction;
using Alfateam.CertificationCenter.Models.Cancellation;
using Alfateam.CertificationCenter.Models.DTO.Cancellation;
using Alfateam.CertificationCenter.Models.DTO.General;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.Core.Attributes.DTO;
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


        public double LatitudeFrom { get; set; }
        public double LongitudeFrom { get; set; }



        [DTOHiddenField]
        public int? AlfateamIDSMSVerificationId { get; set; }

        [DTOHiddenField]
        public int? AlfateamIDEmailVerificationId { get; set; }




        [ForClientOnly]
        public bool IsSMSVerified => AlfateamIDSMSVerificationId != null;

        [ForClientOnly]
        public bool IsEmailVerified => AlfateamIDEmailVerificationId != null;



        [ForClientOnly]
        public CancellationRequestInfoDTO StatusInfo { get; set; }
    }
}
