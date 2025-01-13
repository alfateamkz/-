using Alfateam.Marketing.YandexDirectRestClient.Enums.AdExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdExtensions.Get
{
    public class AdExtensionsSelectionCriteria
    {
        [JsonProperty("Ids")]
        public List<long> Ids { get; set; } = new List<long>();

        [JsonProperty("Types")]
        public List<AdExtensionType> Types { get; set; } = new List<AdExtensionType>();

        [JsonProperty("States")]
        public List<AdExtensionState> States { get; set; } = new List<AdExtensionState>();

        [JsonProperty("Statuses")]
        public List<AdExtensionStatus> Statuses { get; set; } = new List<AdExtensionStatus>();

        [JsonProperty("ModifiedSince")]
        public DateTime ModifiedSince { get; set; }
    }
}
