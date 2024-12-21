using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Delegates
{
    public class DelegateE
    {
        [JsonProperty("user_login")]
        public string UserLogin { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
