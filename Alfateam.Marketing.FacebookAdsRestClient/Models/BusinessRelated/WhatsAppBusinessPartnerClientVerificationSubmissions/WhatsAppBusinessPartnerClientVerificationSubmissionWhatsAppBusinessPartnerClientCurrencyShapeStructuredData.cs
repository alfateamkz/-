using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.WhatsAppBusinessPartnerClientVerificationSubmissions
{
    public class WhatsAppBusinessPartnerClientVerificationSubmissionWhatsAppBusinessPartnerClientCurrencyShapeStructuredData
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }
}
