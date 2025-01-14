using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdImage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("creatives")]
        public List<long> Creatives { get; set; } = new List<long>();

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("height")]
        public uint Height { get; set; }

        [JsonProperty("is_associated_creatives_in_adgroups")]
        public bool IsAssociatedCreativesInAdGroups { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_height")]
        public uint OriginalHeight { get; set; }

        [JsonProperty("original_width")]
        public uint OriginalWidth { get; set; }

        [JsonProperty("permalink_url")]
        public string PermalinkURL { get; set; }

        [JsonProperty("status")]
        public AdImageStatus Status { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("url_128")]
        public string URL128 { get; set; }

        [JsonProperty("width")]
        public uint Width { get; set; }
    }
}
