using Alfateam.ID.Models.Payments.Ways;
using Alfateam.ID.Models.Security.Verifications;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.ID.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<Verification>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CodeVerification), "CodeVerification")]
    public abstract class Verification : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public DateTime ValidBefore { get; set; } = DateTime.UtcNow.AddMinutes(5);

        [NotMapped]
        public bool IsExpired => ValidBefore < DateTime.UtcNow;
        public bool IsVerified { get; set; }

    }
}
