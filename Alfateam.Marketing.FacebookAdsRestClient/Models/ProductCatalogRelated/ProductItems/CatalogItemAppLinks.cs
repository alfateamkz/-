using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Links;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems
{
    public class CatalogItemAppLinks
    {
        [JsonProperty("android")]
        public List<AndroidAppLink> Android { get; set; } = new List<AndroidAppLink>();

        [JsonProperty("ipad")]
        public List<IosAppLink> iPad { get; set; } = new List<IosAppLink>();

        [JsonProperty("iphone")]
        public List<IosAppLink> iPhone { get; set; } = new List<IosAppLink>();

        [JsonProperty("web")]
        public List<WebAppLink> Web { get; set; } = new List<WebAppLink>();

        [JsonProperty("windows")]
        public List<WindowsAppLink> Windows { get; set; } = new List<WindowsAppLink>();

        [JsonProperty("windows_phone")]
        public List<WindowsPhoneAppLink> WindowsPhone { get; set; } = new List<WindowsPhoneAppLink>();

        [JsonProperty("windows_universal")]
        public List<WindowsAppLink> WindowsUniversal { get; set; } = new List<WindowsAppLink>();
    }
}
