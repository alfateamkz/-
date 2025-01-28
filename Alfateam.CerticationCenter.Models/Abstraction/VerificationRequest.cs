using Alfateam.CertificationCenter.Models.General;
using Alfateam.CertificationCenter.Models.IssueRequests;
using Alfateam.CertificationCenter.Models.Verification;
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
    [JsonKnownType(typeof(PersonalVerificationRequest), "PersonalVerificationRequest")]
    public class VerificationRequest : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public string AlfateamIDFrom { get; set; }
        public double LatitudeFrom { get; set; }
        public double LongitudeFrom { get; set; }


        public VerificationRequestInfo StatusInfo { get; set; }
    }
}
