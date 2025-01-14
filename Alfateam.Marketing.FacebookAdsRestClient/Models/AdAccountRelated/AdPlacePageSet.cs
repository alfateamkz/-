using Alfateam.Marketing.FacebookAdsRestClient.Models.General.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdPlacePageSet
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("location_types")]
        public List<string> LocationTypes { get; set; } = new List<string>();

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pages_count")]
        public int PagesCount { get; set; }

        [JsonProperty("parent_page")]
        public Page ParentPage { get; set; }
    }
}
