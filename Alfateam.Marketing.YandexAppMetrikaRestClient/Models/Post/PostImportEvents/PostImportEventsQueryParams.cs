using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Post;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostImportEvents
{
    public class PostImportEventsQueryParams : PostAPIGeneralQueryParams
    {
        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("event_json")]
        public string EventJSON { get; set; }
     
    }
}
