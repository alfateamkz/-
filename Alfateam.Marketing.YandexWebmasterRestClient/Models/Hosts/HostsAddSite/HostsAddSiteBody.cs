using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Hosts.HostsAddSite
{
    public class HostsAddSiteBody
    {
        [JsonProperty("host_url")]
        public string HostURL { get; set; }
    }
}
