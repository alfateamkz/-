using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Toggle
{
    public class BidModifiersToggleResultBody
    {
        [JsonProperty("ToggleResults")]
        public List<ToggleResult> ToggleResults { get; set; } = new List<ToggleResult>();
    }
}
