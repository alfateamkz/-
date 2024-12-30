using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.TrueRevenueTax.GetTaxesList
{
    public class GetTaxesListResponse
    {
        [JsonProperty("taxes")]
        public List<TrueRevenueTaxRule> Taxes { get; set; } = new List<TrueRevenueTaxRule>();
    }
}
