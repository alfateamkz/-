using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Get
{
    public class DesktopAdjustmentGet
    {
        [JsonProperty("BidModifier")]
        public int BidModifier { get; set; }
    }
}
