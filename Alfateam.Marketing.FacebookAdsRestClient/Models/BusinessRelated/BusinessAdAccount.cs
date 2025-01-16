using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated
{
    public class BusinessAdAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("business_id")]
        public long BusinessId { get; set; }

        [JsonProperty("end_advertiser_id")]
        public string EndAdvertiserId { get; set; }

        [JsonProperty("media_agency_id")]
        public string MediaAgencyId { get; set; }

        [JsonProperty("partner_id")]
        public string PartnerId { get; set; }

        [JsonProperty("seer_ad_account_restricted_by_soft_desc_challenge")]
        public bool SeerAdAccountRestrictedBySoftDescChallenge { get; set; }

        [JsonProperty("soft_desc_challenge_credential_id")]
        public string SoftDescChallengeCredentialId { get; set; }

        [JsonProperty("soft_desc_challenge_localized_auth_amount")]
        public int SoftDescChallengeLocalizedAuthAmount { get; set; }
    }
}
