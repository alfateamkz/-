using Alfateam.Marketing.FacebookAdsRestClient.Models.General.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class MailingAddress
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("city_page")]
        public Page CityPage { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("street1")]
        public string Street1 { get; set; }

        [JsonProperty("street2")]
        public string Street2 { get; set; }
    }
}
