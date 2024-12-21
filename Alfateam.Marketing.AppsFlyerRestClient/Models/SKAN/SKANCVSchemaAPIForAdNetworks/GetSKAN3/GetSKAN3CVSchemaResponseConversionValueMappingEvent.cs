using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN3
{
    public class GetSKAN3CVSchemaResponseConversionValueMappingEvent
    {
        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("mapped_event_name")]
        public string MappedEventName { get; set; }

        [JsonProperty("event_counter")]
        public int EventCounter { get; set; }

        [JsonProperty("conversion_event")]
        public bool ConversionEvent { get; set; }

        [JsonProperty("event_currency")]
        public string EventCurrency { get; set; }

        [JsonProperty("min_event_revenue")]
        public double MinEventRevenue { get; set; }

        [JsonProperty("max_event_revenue")]
        public double MaxEventRevenue { get; set; }

        [JsonProperty("event_revenue_usd")]
        public double EventRevenueUSD { get; set; }

        [JsonProperty("min_event_counter")]
        public int MinEventCounter { get; set; }

        [JsonProperty("max_event_counter")]
        public int MaxEventCounter { get; set; }
    }
}
