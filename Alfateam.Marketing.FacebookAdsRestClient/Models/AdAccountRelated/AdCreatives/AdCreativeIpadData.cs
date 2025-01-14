using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeIpadData
    {
        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("app_store_id")]
        public string AppStoreId { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
