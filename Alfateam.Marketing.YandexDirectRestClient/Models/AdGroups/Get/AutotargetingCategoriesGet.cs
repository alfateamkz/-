using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class AutotargetingCategoriesGet
    {
        [JsonProperty("Items")]
        public List<AutotargetingCategoriesGetItem> Items { get; set; } = new List<AutotargetingCategoriesGetItem>();
    }
}
