using Alfateam.Core;
using Alfateam.Marketing.Models.Ads.Accounts;
using Alfateam.Marketing.Models.ExternalInteractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<ExternalInteraction>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamMetricsExtInteraction), "AlfateamMetricsExtInteraction")]
    [JsonKnownType(typeof(AlfateamWebvisorExtInteraction), "AlfateamWebvisorExtInteraction")]
    public class ExternalInteraction : AbsModel
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
