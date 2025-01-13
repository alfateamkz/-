using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models
{
    public class AdAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("account_id")]
        public string account_id { get; set; }

        [JsonProperty("account_status")]
        public AdAccountStatus account_status { get; set; }

        [JsonProperty("ad_account_promotable_objects")]
        public AdAccountPromotableObjects ad_account_promotable_objects { get; set; }

        [JsonProperty("age")]
        public float age { get; set; }

        [JsonProperty("agency_client_declaration")]
        public AgencyClientDeclaration agency_client_declaration { get; set; }

        [JsonProperty("amount_spent")]
        public double amount_spent { get; set; }

        [JsonProperty("balance")]
        public double balance { get; set; }

        [JsonProperty("brand_safety_content_filter_levels")]
        public List<string> brand_safety_content_filter_levels { get; set; } = new List<string>();

        [JsonProperty("business")]
        public Business business { get; set; }

        [JsonProperty("business_city")]
        public string business_city { get; set; }

        [JsonProperty("business_country_code")]
        public string business_country_code { get; set; }

        [JsonProperty("business_name")]
        public string business_name { get; set; }

        [JsonProperty("business_state")]
        public string business_state { get; set; }

        [JsonProperty("business_street")]
        public string business_street { get; set; }
    }
}
