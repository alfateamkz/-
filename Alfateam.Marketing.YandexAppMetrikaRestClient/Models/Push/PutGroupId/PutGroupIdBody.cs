using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PutGroupId
{
    public class PutGroupIdBody
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("send_rate")]
        public int SendRate { get; set; }
    }
}
