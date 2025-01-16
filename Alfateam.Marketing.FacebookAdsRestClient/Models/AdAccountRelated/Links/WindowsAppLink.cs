using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Links
{
    public class WindowsAppLink
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("package_family_name")]
        public string PackageFamilyName { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
