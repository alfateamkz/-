using Alfateam.Marketing.YandexDirectRestClient.Enums.Changes;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Clients
{
    public class ClientsParams<T>
    {
        [JsonProperty("method")]
        public ClientsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
