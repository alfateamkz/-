using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Moderate
{
    public class AdsModerateResultBody
    {
        [JsonProperty("ModerateResults")]
        public List<ActionResult> ModerateResults { get; set; } = new List<ActionResult>();
    }
}
