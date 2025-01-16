using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class Experience
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("with")]
        public List<User> With { get; set; } = new List<User>();
    }
}
