using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GetMessengers
{
    public class GetMessengersResponse
    {
        [JsonProperty("messengers")]
        public List<Messenger> Messengers { get; set; } = new List<Messenger>();
    }
}
