using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Sitelinks.Get
{
    public class SitelinksSetGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Sitelinks")]
        public List<Sitelink> Sitelinks { get; set; } = new List<Sitelink>();
    }
}
