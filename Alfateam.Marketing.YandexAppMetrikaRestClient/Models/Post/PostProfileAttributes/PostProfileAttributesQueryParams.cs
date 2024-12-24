using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostProfileAttributes
{
    public class PostProfileAttributesQueryParams
    {
        [JsonProperty("post_api_key")]
        public string PostAPIKey { get; set; }

        [JsonProperty("application_id")]
        public int ApplicationId { get; set; }

        [JsonProperty("profile_id")]
        public string ProfileId { get; set; }

        [JsonProperty("attributes")]
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
    }
}
