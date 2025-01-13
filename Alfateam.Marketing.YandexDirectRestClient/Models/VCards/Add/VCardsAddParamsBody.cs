using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.VCards.Add
{
    public class VCardsAddParamsBody
    {
        [JsonProperty("VCards")]
        public List<VCardAddItem> VCards { get; set; } = new List<VCardAddItem>();
    }
}
