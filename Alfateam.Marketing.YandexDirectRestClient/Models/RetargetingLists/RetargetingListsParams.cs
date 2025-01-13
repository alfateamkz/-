using Alfateam.Marketing.YandexDirectRestClient.Enums.RetargetingLists;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Sitelinks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists
{
    public class RetargetingListsParams<T>
    {
        [JsonProperty("method")]
        public RetargetingListsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
