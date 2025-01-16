using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class PaymentPricepoints
    {
        [JsonProperty("mobile")]
        public List<PaymentPricepoint> Mobile { get; set; } = new List<PaymentPricepoint>();
    }
}
