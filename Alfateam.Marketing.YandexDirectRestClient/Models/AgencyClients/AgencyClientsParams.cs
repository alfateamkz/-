using Alfateam.Marketing.YandexDirectRestClient.Enums.Ads;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients
{
    public class AgencyClientsParams<T>
    {
        [JsonProperty("method")]
        public AgencyClientsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
