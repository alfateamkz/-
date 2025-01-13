using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicTextAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets
{
    public class WebpageCondition
    {
        [JsonProperty("Operand")]
        public WebpageConditionOperandEnum Operand { get; set; }

        [JsonProperty("Operator")]
        public WebpageStringConditionOperatorEnum Operator { get; set; }

        [JsonProperty("Arguments")]
        public List<string> Arguments { get; set; } = new List<string>();
    }
}
