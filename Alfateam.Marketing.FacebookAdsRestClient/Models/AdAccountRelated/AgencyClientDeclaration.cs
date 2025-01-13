using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AgencyClientDeclaration
    {
        [JsonProperty("agency_representing_client")]
        public bool AgencyRepresentingClient { get; set; }

        [JsonProperty("client_based_in_france")]
        public bool ClientBasedInFrance { get; set; }

        [JsonProperty("client_city")]
        public string ClientCity { get; set; }

        [JsonProperty("client_country_code")]
        public string ClientCountryCode { get; set; }

        [JsonProperty("client_email_address")]
        public string ClientEmailAddress { get; set; }

        [JsonProperty("client_name")]
        public string ClientName { get; set; }

        [JsonProperty("client_postal_code")]
        public string ClientPostalCode { get; set; }

        [JsonProperty("client_province")]
        public string ClientProvince { get; set; }

        [JsonProperty("client_street")]
        public string ClientStreet { get; set; }

        [JsonProperty("client_street2")]
        public string ClientStreet2 { get; set; }

        [JsonProperty("has_written_mandate_from_advertiser")]
        public bool HaWrittenMandateFromAdvertiser { get; set; }

        [JsonProperty("is_client_paying_invoices")]
        public bool IsClientPayingInvoices { get; set; }
    }
}
