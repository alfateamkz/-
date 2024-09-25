using Alfateam.Core;
using Alfateam.ID.Models.Payments.Ways;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.ID.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<BindedPaymentWay>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(BindedBankCard), "BindedBankCard")]
    public class BindedPaymentWay : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public int UserId { get; set; }
    }
}
