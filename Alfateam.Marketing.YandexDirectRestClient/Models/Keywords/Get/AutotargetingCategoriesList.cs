using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Get
{
    public class AutotargetingCategoriesList
    {
        [JsonProperty("Items")]
        public List<AutotargetingCategoriesItem> Items { get; set; } = new List<AutotargetingCategoriesItem>();
    }
}
