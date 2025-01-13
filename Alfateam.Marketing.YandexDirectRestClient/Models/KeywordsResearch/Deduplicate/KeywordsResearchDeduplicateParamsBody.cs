using Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordsResearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordsResearch.Deduplicate
{
    public class KeywordsResearchDeduplicateParamsBody
    {
        [JsonProperty("Keywords")]
        public List<DeduplicateRequestItem> Keywords { get; set; } = new List<DeduplicateRequestItem>();

        [JsonProperty("Operation")]
        public List<DeduplicateOperationEnum> Operation { get; set; } = new List<DeduplicateOperationEnum>();
    }
}
