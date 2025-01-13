using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Set
{
    public class BidModifiersSetResultBody
    {
        [JsonProperty("SetResults")]
        public List<ActionResult> SetResults { get; set; } = new List<ActionResult>();
    }
}
