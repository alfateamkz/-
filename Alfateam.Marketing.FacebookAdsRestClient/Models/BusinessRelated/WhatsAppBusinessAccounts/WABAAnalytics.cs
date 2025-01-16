using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.WhatsAppBusinessAccounts
{
    public class WABAAnalytics
    {
        [JsonProperty("country_codes")]
        public List<string> CountryCodes { get; set; } = new List<string>();

        [JsonProperty("data_points")]
        public List<WABAAnalyticsDataPoint> DataPoints { get; set; } = new List<WABAAnalyticsDataPoint>();

        [JsonProperty("granularity")]
        public string Granularity { get; set; }

        [JsonProperty("phone_numbers")]
        public List<long> PhoneNumbers { get; set; } = new List<long>();
    }
}
