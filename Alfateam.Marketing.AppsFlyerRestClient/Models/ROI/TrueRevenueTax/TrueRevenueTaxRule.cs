using Alfateam.Marketing.AppsFlyerRestClient.Enums.ROI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.TrueRevenueTax
{
    public class TrueRevenueTaxRule
    {
        [JsonProperty("tax_name")]
        public string TaxName { get; set; }

        [JsonProperty("tax_rate")]
        public double TaxRate { get; set; }

        [JsonProperty("tax_exclusive")]
        public bool TaxExclusive { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("subdivision")]
        public string Subdivision { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("deduction_order")]
        public TrueRevenueTaxRuleDeductionOrder DeductionOrder { get; set; }
    }
}
