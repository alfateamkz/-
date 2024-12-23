using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.GetHostById
{
    public class HostMainMirror
    {
        [JsonProperty("host_id")]
        public string HostId { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("ascii_host_url")]
        public string ASCIIHostURL { get; set; }

        [JsonProperty("unicode_host_url")]
        public string UnicodeHostURL { get; set; }
    }
}
