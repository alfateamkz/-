using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.VCards
{
    public class InstantMessenger
    {
        [JsonProperty("MessengerClient")]
        public string MessengerClient { get; set; }

        [JsonProperty("MessengerLogin")]
        public string MessengerLogin { get; set; }
    }
}
