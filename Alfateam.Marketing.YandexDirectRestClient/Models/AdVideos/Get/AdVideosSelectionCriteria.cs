using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdVideos.Get
{
    public class AdVideosSelectionCriteria
    {
        [JsonProperty("Ids")]
        public List<string> Ids { get; set; } = new List<string>();
    }
}
