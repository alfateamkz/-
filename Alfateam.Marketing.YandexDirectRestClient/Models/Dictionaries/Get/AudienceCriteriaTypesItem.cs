using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class AudienceCriteriaTypesItem
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("BlockElement")]
        public string BlockElement { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("CanSelect")]
        public CanSelectEnum CanSelect { get; set; }
    }
}
