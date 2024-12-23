using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.SiteQuality.NewFolder
{
    public class GetSQIHistoryResponse
    {
        [JsonProperty("points")]
        public List<SQIHistoryItem> Points { get; set; } = new List<SQIHistoryItem>();
    }
}
