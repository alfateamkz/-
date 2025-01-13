using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class AdCategoriesItem
    {
        [JsonProperty("AdCategory")]
        public string AdCategory { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}
