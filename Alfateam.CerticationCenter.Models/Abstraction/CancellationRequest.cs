using Alfateam.CertificationCenter.Models.Cancellation;
using Alfateam.CertificationCenter.Models.Files;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.Core;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CertificationCenter.Models.Abstraction
{
    [JsonConverter(typeof(JsonKnownTypesConverter<CancellationRequest>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DigitalPOACancellationRequest), "DigitalPOACancellationRequest")]
    [JsonKnownType(typeof(EDSCancellationRequest), "EDSCancellationRequest")]
    public class CancellationRequest : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string AlfateamIDFrom { get; set; }
        public double LatitudeFrom { get; set; }
        public double LongitudeFrom { get; set; }


        public int? AlfateamIDSMSVerificationId { get; set; }
        public int? AlfateamIDEmailVerificationId { get; set; }


        public CancellationRequestInfo StatusInfo { get; set; }
    }
}
