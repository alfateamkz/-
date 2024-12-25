using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Management;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access
{
    public class Grant
    {
        [JsonProperty("user_login")]
        public string UserLogin { get; set; }

        [JsonProperty("user_uid")]
        public int UserUID { get; set; }

        [JsonProperty("perm")]
        public GrantPermission Perm { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("partners")]
        public List<int> Partners { get; set; } = new List<int>();

        [JsonProperty("event_labels")]
        public List<string> EventLabels { get; set; } = new List<string>();
    }
}
