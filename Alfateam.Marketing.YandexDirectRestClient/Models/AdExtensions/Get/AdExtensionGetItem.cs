using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AdExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdExtensions.Get
{
    public class AdExtensionGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Associated")]
        public YesNoEnum Associated { get; set; }

        [JsonProperty("Type")]
        public AdExtensionType Type { get; set; }

        [JsonProperty("Callout")]
        public Callout Callout { get; set; }

        [JsonProperty("State")]
        public AdExtensionState State { get; set; }

        [JsonProperty("Status")]
        public AdExtensionStatus Status { get; set; }

        [JsonProperty("StatusClarification")]
        public string StatusClarification { get; set; }
    }
}
