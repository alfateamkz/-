using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class PageCategory
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("api_enum")]
        public string APIEnum { get; set; }

        [JsonProperty("fb_page_categories")]
        public List<PageCategory> FBPageCategories { get; set; } = new List<PageCategory>();

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
