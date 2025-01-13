using Alfateam.Marketing.YandexDirectRestClient.Enums.Leads;
using Alfateam.Marketing.YandexDirectRestClient.Enums.NegativeKeywordSharedSets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Leads
{
    public class LeadsParams<T>
    {
        [JsonProperty("method")]
        public LeadsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
