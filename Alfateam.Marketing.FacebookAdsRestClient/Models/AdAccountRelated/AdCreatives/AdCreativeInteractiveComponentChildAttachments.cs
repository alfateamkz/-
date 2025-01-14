using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeInteractiveComponentChildAttachments
    {
        [JsonProperty("components")]
        public List<AdCreativeInteractiveComponent> Components { get; set; } = new List<AdCreativeInteractiveComponent>();
    }
}
