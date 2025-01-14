using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class ExtendedCreditInvoiceGroup
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("auto_enroll")]
        public bool AutoEnroll { get; set; }

        [JsonProperty("customer_po_number")]
        public string CustomerPONumber { get; set; }

        [JsonProperty("email")]
        public ExtendedCreditEmail Email { get; set; }

        [JsonProperty("emails")]
        public List<string> Emails { get; set; } = new List<string>();

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
