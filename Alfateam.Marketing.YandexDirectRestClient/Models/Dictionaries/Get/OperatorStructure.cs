using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class OperatorStructure
    {
        [JsonProperty("MaxItems")]
        public int MaxItems { get; set; }

        [JsonProperty("Type")]
        public StringConditionOperatorEnum Type { get; set; }
    }
}
