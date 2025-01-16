using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.WhatsAppBusinessPartnerClientVerificationSubmissions
{
    public class WhatsAppBusinessPartnerClientVerificationSubmissionWhatsAppBusinessPartnerClientAddressStructuredData
    {
        [JsonProperty("city_or_town")]
        public string CityOrTown { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("state_province_or_region")]
        public string StateProvinceOrRegion { get; set; }

        [JsonProperty("street_address_1")]
        public string StreetAddress1 { get; set; }

        [JsonProperty("street_address_2")]
        public string StreetAddress2 { get; set; }
    }
}
