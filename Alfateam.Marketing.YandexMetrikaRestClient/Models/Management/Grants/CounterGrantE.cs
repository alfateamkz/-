using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Grants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants
{
    public class CounterGrantE
    {
        [JsonProperty("perm")]
        public CounterGrantEPerm Perm { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("partner_data_access")]
        public bool PartnerDataAccess { get; set; }

        [JsonProperty("user_login")]
        public string UserLogin { get; set; }

        [JsonProperty("user_uid")]
        public long UserUID { get; set; }
    }
}
