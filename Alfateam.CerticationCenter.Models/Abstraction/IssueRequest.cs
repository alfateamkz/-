using Alfateam.CertificationCenter.Models.Cancellation;
using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.IssueRequests;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<IssueRequest>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DigitalPOAIssueRequest), "DigitalPOAIssueRequest")]
    [JsonKnownType(typeof(EDSIssueRequest), "EDSIssueRequest")]
    public class IssueRequest : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public string AlfateamIDFrom { get; set; }
        public double LatitudeFrom { get; set; }
        public double LongitudeFrom { get; set; }



        public IssueRequestInfo StatusInfo { get; set; }
    }
}
