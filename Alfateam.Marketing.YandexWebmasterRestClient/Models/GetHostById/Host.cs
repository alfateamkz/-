using Alfateam.Marketing.YandexWebmasterRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.GetHostById
{
    public class Host
    {
        [JsonProperty("host_id")]
        public string HostId { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("ascii_host_url")]
        public string ASCIIHostURL { get; set; }

        [JsonProperty("unicode_host_url")]
        public string UnicodeHostURL { get; set; }

        [JsonProperty("main_mirror")]
        public HostMainMirror main_mirror { get; set; }

        [JsonProperty("host_data_status")]
        public ApiHostDataStatus HostDataStatus { get; set; }

        [JsonProperty("host_display_name")]
        public string HostDisplayName { get; set; }
    }
}
