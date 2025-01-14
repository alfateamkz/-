using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General.Pages
{
    public class PagePaymentOptions
    {
        [JsonProperty("amex")]
        public bool AmEx { get; set; }

        [JsonProperty("cash_only")]
        public bool CashOnly { get; set; }

        [JsonProperty("discover")]
        public bool Discover { get; set; }

        [JsonProperty("mastercard")]
        public bool Mastercard { get; set; }

        [JsonProperty("visa")]
        public bool Visa { get; set; }
    }
}
