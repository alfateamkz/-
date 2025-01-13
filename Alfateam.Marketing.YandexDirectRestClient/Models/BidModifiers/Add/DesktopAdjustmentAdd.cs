using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Add
{
    public class DesktopAdjustmentAdd
    {
        [JsonProperty("BidModifier")]
        public int BidModifier { get; set; }
    }
}
