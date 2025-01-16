using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class PublisherBlockList
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("business_owner_id")]
        public long BusinessOwnerId { get; set; }

        [JsonProperty("is_auto_blocking_on")]
        public bool IsAutoBlockingOn { get; set; }

        [JsonProperty("is_eligible_at_campaign_level")]
        public bool IsEligibleAtCampaignLevel { get; set; }

        [JsonProperty("last_update_time")]
        public DateTime LastUpdateTime { get; set; }

        [JsonProperty("last_update_user")]
        public long LastUpdateUser { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_ad_account_id")]
        public long OwnerAdAccountId { get; set; }
    }
}
