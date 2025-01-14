using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Links
{
    public class AndroidAppLink
    {
        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("package")]
        public string Package { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
