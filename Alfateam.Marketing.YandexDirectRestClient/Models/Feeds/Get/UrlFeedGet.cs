using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Get
{
    public class UrlFeedGet
    {
        [JsonProperty("Url")]
        public string URL { get; set; }

        [JsonProperty("RemoveUtmTags")]
        public YesNoEnum RemoveUTMTags { get; set; }

        [JsonProperty("Login")]
        public string Login { get; set; }
    }
}
