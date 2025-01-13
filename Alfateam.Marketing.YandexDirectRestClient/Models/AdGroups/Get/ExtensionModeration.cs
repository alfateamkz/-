using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class ExtensionModeration
    {
        [JsonProperty("Status")]
        public AppIconModerationStatus Status { get; set; }

        [JsonProperty("StatusClarification")]
        public string StatusClarification { get; set; }
    }
}
