using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeSourcingSpec
    {
        [JsonProperty("associated_product_set_id")]
        public long AssociatedProductSetId { get; set; }

        [JsonProperty("site_links_spec")]
        public List<AdCreativeSiteLinksSpec> SiteLinksSpec { get; set; } = new List<AdCreativeSiteLinksSpec>();
    }
}
