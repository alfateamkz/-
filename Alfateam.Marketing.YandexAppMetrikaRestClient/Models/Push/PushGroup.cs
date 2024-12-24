using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push
{
    public class PushGroup
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("app_id")]
        public int AppId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("send_rate")]
        public int SendRate { get; set; }
    }
}
