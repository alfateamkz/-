using Alfateam.Marketing.YandexDirectRestClient.Enums.Bids;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Get
{
    public class SearchPrices
    {
        [JsonProperty("Position")]
        public SearchPricesPositionEnum Position { get; set; }

        [JsonProperty("Price")]
        public long Price { get; set; }
    }
}
