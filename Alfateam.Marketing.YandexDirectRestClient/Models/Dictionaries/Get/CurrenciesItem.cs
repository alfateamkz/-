using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class CurrenciesItem
    {
        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("Properties")]
        public List<ConstantsItem> Properties { get; set; } = new List<ConstantsItem>();
    }
}
