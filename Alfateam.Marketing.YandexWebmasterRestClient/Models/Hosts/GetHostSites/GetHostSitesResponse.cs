using Alfateam.Marketing.YandexWebmasterRestClient.Models.GetHostById;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Hosts.GetHostSites
{
    public class GetHostSitesResponse
    {
        [JsonProperty("hosts")]
        public List<Host> Hosts { get; set; } = new List<Host>();
    }
}
