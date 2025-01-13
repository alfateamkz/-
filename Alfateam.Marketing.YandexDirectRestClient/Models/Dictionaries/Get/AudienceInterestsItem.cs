using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class AudienceInterestsItem
    {
        [JsonProperty("InterestKey")]
        public long InterestKey { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("ParentId")]
        public long ParentId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("InterestType")]
        public InterestTypeEnum InterestType { get; set; }
    }
}
