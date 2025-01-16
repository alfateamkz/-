using Alfateam.Marketing.FacebookAdsRestClient.Abstractions.Models;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class Group : Profile
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("cover")]
        public CoverPhoto Cover { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        [JsonProperty("member_request_count")]
        public int MemberRequestCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parent")]
        public object Parent { get; set; } //TODO: Group or Page

        [JsonProperty("permissions")]
        public string Permissions { get; set; }

        [JsonProperty("privacy")]
        public GroupPrivacy Privacy { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }
    }
}
