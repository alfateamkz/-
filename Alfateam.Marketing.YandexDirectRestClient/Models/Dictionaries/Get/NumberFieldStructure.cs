using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class NumberFieldStructure
    {
        [JsonProperty("Min")]
        public decimal Min { get; set; }

        [JsonProperty("Max")]
        public decimal Max { get; set; }

        [JsonProperty("Precision")]
        public int Precision { get; set; }
    }
}
