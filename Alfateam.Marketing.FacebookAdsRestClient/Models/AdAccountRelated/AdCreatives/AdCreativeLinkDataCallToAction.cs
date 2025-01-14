using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeLinkDataCallToAction
    {
        [JsonProperty("type")]
        public CallToActionType Type { get; set; }

        [JsonProperty("value")]
        public AdCreativeLinkDataCallToActionValue Value { get; set; }
    }
}
