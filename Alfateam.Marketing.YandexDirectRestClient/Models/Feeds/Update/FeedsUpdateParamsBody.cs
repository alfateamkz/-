using Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Update
{
    public class FeedsUpdateParamsBody
    {
        [JsonProperty("Feeds")]
        public List<FeedUpdateItem> Feeds { get; set; } = new List<FeedUpdateItem>();
    }
}
