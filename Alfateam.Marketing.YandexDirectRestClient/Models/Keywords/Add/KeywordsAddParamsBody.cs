using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Add
{
    public class KeywordsAddParamsBody
    {
        [JsonProperty("Keywords")]
        public List<KeywordAddItem> Keywords { get; set; } = new List<KeywordAddItem>();
    }
}
