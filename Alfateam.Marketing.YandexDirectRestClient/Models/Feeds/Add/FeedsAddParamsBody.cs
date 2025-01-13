using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Add
{
    public class FeedsAddParamsBody
    {
        [JsonProperty("Feeds")]
        public List<FeedAddItem> Feeds { get; set; } = new List<FeedAddItem>();
    }
}
