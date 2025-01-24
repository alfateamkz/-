using Alfateam.Core;
using Alfateam.Telephony.Models.ExternalInteractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ExtInteraction>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CallbackExtInteraction), "CallbackExtInteraction")]
    [JsonKnownType(typeof(CallUsExtInteraction), "CallUsExtInteraction")]
    public class ExtInteraction : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string Title { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
