using Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Get;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Update
{
    public class KeywordUpdateItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Keyword")]
        public string Keyword { get; set; }

        [JsonProperty("UserParam1")]
        public string UserParam1 { get; set; }

        [JsonProperty("UserParam2")]
        public string UserParam2 { get; set; }

        [JsonProperty("AutotargetingCategories")]
        public List<AutotargetingCategoriesItem> AutotargetingCategories { get; set; } = new List<AutotargetingCategoriesItem>();

        [JsonProperty("AutotargetingSettings")]
        public AutotargetingSettingsGetItem AutotargetingSettings { get; set; }
    }
}
