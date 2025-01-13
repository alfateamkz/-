using Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Update
{
    public class KeywordsUpdateParamsBody
    {
        [JsonProperty("Keywords")]
        public List<KeywordUpdateItem> Keywords { get; set; } = new List<KeywordUpdateItem>();
    }
}
