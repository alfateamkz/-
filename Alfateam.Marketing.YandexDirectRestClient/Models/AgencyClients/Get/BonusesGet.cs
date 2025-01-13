using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get
{
    public class BonusesGet
    {
        [JsonProperty("AwaitingBonus")]
        public long AwaitingBonus { get; set; }

        [JsonProperty("AwaitingBonusWithoutNds")]
        public long AwaitingBonusWithoutNds { get; set; }
    }
}
