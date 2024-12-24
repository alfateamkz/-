using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostAdRevenue
{
    public class PostAdRevenueQueryParams : PostAPIGeneralQueryParams
    {
        [JsonProperty("revenue")]
        public double Revenue { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("ad_type")]
        public AdType AdType { get; set; }

        [JsonProperty("ad_network")]
        public string AdNetwork { get; set; }

        [JsonProperty("ad_unit_id")]
        public string AdUnitId { get; set; }

        [JsonProperty("ad_unit_name")]
        public string AdUnitName { get; set; }

        [JsonProperty("ad_placement_id")]
        public string AdPlacementId { get; set; }

        [JsonProperty("ad_placement_name")]
        public string AdPlacementName { get; set; }

        [JsonProperty("precision")]
        public Precision Precision { get; set; }

        [JsonProperty("payload")]
        public Dictionary<string, string> Payload { get; set; } = new Dictionary<string, string>();
    }

}
