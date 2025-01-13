using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdAccountPromotableObjects
    {
        [JsonProperty("promotable_app_ids")]
        public List<string> PromotableAppIds { get; set; } = new List<string>();

        [JsonProperty("promotable_page_ids")]
        public List<string> PromotablePageIds { get; set; } = new List<string>();

        [JsonProperty("promotable_urls")]
        public List<string> PromotableURLs { get; set; } = new List<string>();
    }
}
