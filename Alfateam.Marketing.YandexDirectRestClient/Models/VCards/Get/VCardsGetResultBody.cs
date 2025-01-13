using Alfateam.Marketing.YandexDirectRestClient.Models.VCards.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.VCards.Get
{
    public class VCardsGetResultBody
    {
        [JsonProperty("VCards")]
        public List<VCardGetItem> VCards { get; set; } = new List<VCardGetItem>();
    }
}
