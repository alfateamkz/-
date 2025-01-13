using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Profile
{
    public class VC_RUProfileCounters
    {
        [JsonProperty("subscribers")]
        public int Subscribers { get; set; }

        [JsonProperty("subscriptions")]
        public int Subscriptions { get; set; }

        [JsonProperty("entries")]
        public int Entries { get; set; }

        [JsonProperty("comments")]
        public int Comments { get; set; }
    }
}
