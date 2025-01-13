using Alfateam.Marketing.YandexDirectRestClient.Abstractions.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Add
{
    public class MultiIdsActionResult : AbsActionResult
    {
        [JsonProperty("Ids")]
        public List<long> Ids { get; set; } = new List<long>();
    }
}
