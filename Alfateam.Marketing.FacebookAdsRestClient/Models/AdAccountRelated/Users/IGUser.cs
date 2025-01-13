using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users
{
    public class IGUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("business_discovery")]
        public IGUser BusinessDiscovery { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("follows_count")]
        public int FollowsCount { get; set; }

        [JsonProperty("ig_id")]
        public int IgId { get; set; }

        [JsonProperty("legacy_instagram_user_id")]
        public int LegacyInstagramUserId { get; set; }

        [JsonProperty("media_count")]
        public int MediaCount { get; set; }

        [JsonProperty("mentioned_comment")]
        public ShadowIGComment MentionedComment { get; set; }

        [JsonProperty("mentioned_media")]
        public ShadowIGMedia MentionedMedia { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profile_picture_url")]
        public string ProfilePictureURL { get; set; }

        [JsonProperty("shopping_review_status")]
        public ShoppingReviewStatus ShoppingReviewStatus { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }
    }
}
