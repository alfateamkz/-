using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Add
{
    public class BidModifiersAddResultBody
    {
        [JsonProperty("AddResults")]
        public List<MultiIdsActionResult> AddResults { get; set; } = new List<MultiIdsActionResult>();
    }
}
