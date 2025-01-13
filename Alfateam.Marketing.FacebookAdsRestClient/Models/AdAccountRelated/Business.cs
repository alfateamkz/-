using Alfateam.Marketing.FacebookAdsRestClient.Abstractions.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class Business
    {
        [JsonProperty("id")]
        public long id { get; set; }

        [JsonProperty("block_offline_analytics")]
        public bool block_offline_analytics { get; set; }

        [JsonProperty("collaborative_ads_managed_partner_business_info")]
        public ManagedPartnerBusiness collaborative_ads_managed_partner_business_info { get; set; }

        [JsonProperty("collaborative_ads_managed_partner_eligibility")]
        public BusinessManagedPartnerEligibility collaborative_ads_managed_partner_eligibility { get; set; }

        [JsonProperty("created_by")]
        public AbsUser created_by { get; set; }

        [JsonProperty("created_time")]
        public DateTime created_time { get; set; }

        [JsonProperty("extended_updated_time")]
        public DateTime extended_updated_time { get; set; }

        [JsonProperty("is_hidden")]
        public bool is_hidden { get; set; }

        [JsonProperty("link")]
        public string link { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("payment_account_id")]
        public long payment_account_id { get; set; }

        [JsonProperty("primary_page")]
        public Page primary_page { get; set; }
    }
}
