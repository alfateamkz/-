using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class VideoExtensionAddItem
    {
        [JsonProperty("CreativeId")]
        public long CreativeId { get; set; }
    }
}
