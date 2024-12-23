using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps.HostUserAddedSitemapsPost
{
    public class HostUserAddedSitemapsPostBody
    {
        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
