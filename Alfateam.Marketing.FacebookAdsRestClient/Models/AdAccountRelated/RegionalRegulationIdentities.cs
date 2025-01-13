using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class RegionalRegulationIdentities
    {
        [JsonProperty("taiwan_finserv_beneficiary")]
        public string TaiwanFinservBeneficiary { get; set; }

        [JsonProperty("taiwan_finserv_payer")]
        public string TaiwanFinservPayer { get; set; }

        [JsonProperty("australia_finserv_beneficiary")]
        public string AustraliaFinservBeneficiary { get; set; }

        [JsonProperty("australia_finserv_payer")]
        public string AustraliaFinservPayer { get; set; }

        [JsonProperty("taiwan_universal_beneficiary")]
        public string TaiwanUniversalBeneficiary { get; set; }

        [JsonProperty("taiwan_universal_payer")]
        public string TaiwanUniversalPayer { get; set; }
    }
}
