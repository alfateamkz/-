using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Hosts.HostsAddSite
{
    public class HostsAddSiteResponse
    {
        [JsonProperty("host_id")]
        public string HostId { get; set; }
    }
}
