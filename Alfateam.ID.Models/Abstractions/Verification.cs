using Alfateam.ID.Models.Payments.Ways;
using Alfateam.ID.Models.Security.Verifications;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.ID.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<Verification>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CodeVerification), "CodeVerification")]
    public abstract class Verification : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
