using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeLinkDataCallToActionValue
    {
        [JsonProperty("app_destination")]
        public string AppDestination { get; set; }

        [JsonProperty("app_link")]
        public string AppLink { get; set; }

        [JsonProperty("application")]
        public string Application { get; set; }

        [JsonProperty("event_id")]
        public long EventId { get; set; }

        [JsonProperty("lead_gen_form_id")]
        public string LeadGenFormId { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("link_caption")]
        public string LinkCaption { get; set; }

        [JsonProperty("link_format")]
        public string LinkFormat { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("product_link")]
        public string ProductLink { get; set; }
    }
}
