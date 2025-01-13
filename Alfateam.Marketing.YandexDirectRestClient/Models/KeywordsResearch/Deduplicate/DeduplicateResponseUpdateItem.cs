using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordsResearch.Deduplicate
{
    public class DeduplicateResponseUpdateItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Keyword")]
        public string Keyword { get; set; }
    }
}
