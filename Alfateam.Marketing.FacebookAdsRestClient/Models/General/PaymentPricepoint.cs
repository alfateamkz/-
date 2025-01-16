using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class PaymentPricepoint
    {
        [JsonProperty("credits")]
        public float Credits { get; set; }

        [JsonProperty("local_currency")]
        public string LocalCurrency { get; set; }

        [JsonProperty("user_price")]
        public string UserPrice { get; set; }
    }
}
