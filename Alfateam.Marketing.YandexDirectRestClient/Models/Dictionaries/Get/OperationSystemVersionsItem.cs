using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class OperationSystemVersionsItem
    {
        [JsonProperty("OsName")]
        public string OSName { get; set; }

        [JsonProperty("OsVersion")]
        public string OSVersion { get; set; }
    }
}
