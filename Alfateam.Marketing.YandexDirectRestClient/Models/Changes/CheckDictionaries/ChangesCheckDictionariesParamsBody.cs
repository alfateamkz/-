using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Changes.CheckDictionaries
{
    public class ChangesCheckDictionariesParamsBody
    {
        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
