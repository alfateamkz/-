using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class PageStartInfo
    {
        [JsonProperty("date")]
        public PageStartDate Date { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
