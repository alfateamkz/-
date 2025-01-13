using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordsResearch.Deduplicate
{
    public class KeywordsResearchDeduplicateResultBody
    {
        [JsonProperty("Add")]
        public List<DeduplicateResponseAddItem> Add { get; set; } = new List<DeduplicateResponseAddItem>();

        [JsonProperty("Update")]
        public List<DeduplicateResponseUpdateItem> Update { get; set; } = new List<DeduplicateResponseUpdateItem>();

        [JsonProperty("Delete")]
        public IdsCriteria Delete { get; set; }

        [JsonProperty("Failure")]
        public List<DeduplicateErrorItem> Failure { get; set; } = new List<DeduplicateErrorItem>();
    }
}
