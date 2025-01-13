using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups
{
    public class AdGroupsParams<T>
    {
        [JsonProperty("method")]
        public AdGroupsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
