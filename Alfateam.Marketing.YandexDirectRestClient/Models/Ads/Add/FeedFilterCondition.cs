using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class FeedFilterCondition
    {
        [JsonProperty("Operand")]
        public string Operand { get; set; }

        [JsonProperty("Operator")]
        public StringConditionOperatorEnum Operator { get; set; }

        [JsonProperty("Arguments")]
        public List<string> Arguments { get; set; } = new List<string>();
    }
}
