using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters
{
    public class WebvisorOptions
    {
        [JsonProperty("arch_enabled")]
        public bool ArchEnabled { get; set; }

        [JsonProperty("arch_type")]
        public WebvisorOptionsArchType ArchType { get; set; }

        [JsonProperty("load_player_type")]
        public WebvisorOptionsLoadPlayerType LoadPlayerType { get; set; }

        [JsonProperty("urls")]
        public string URLs { get; set; }

        [JsonProperty("wv_forms")]
        public bool WVForms { get; set; }

        [JsonProperty("wv_version")]
        public int WVVersion { get; set; }
    }
}
