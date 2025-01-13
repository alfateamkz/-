using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordsResearch.Deduplicate
{
    public class DeduplicateResponseAddItem
    {
        [JsonProperty("Keyword")]
        public string Keyword { get; set; }
    }
}
