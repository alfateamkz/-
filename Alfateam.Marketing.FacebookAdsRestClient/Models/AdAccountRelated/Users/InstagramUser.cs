using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users
{
    public class InstagramUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("follows_count")]
        public int FollowsCount { get; set; }

        [JsonProperty("followed_by_count")]
        public int FollowedByCount { get; set; }

        [JsonProperty("has_profile_picture")]
        public bool HasProfilePicture { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("is_published")]
        public bool IsPublished { get; set; }

        [JsonProperty("media_count")]
        public int MediaCount { get; set; }

        [JsonProperty("profile_pic")]
        public string ProfilePic { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
