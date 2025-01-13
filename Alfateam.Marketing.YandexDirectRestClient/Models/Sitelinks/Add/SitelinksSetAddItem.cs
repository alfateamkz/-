using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Sitelinks.Add
{
    public class SitelinksSetAddItem
    {
        [JsonProperty("Sitelinks")]
        public List<Sitelink> Sitelinks { get; set; } = new List<Sitelink>();
    }
}
