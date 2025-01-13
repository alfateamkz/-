using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class InterestsItem
    {
        [JsonProperty("InterestId")]
        public long InterestId { get; set; }

        [JsonProperty("ParentId")]
        public long ParentId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("IsTargetable")]
        public YesNoEnum IsTargetable { get; set; }
    }
}
