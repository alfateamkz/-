using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants.Individual.DeleteGrant
{
    public class DeleteGrantQueryParams
    {
        [JsonProperty("user_login")]
        public string UserLogin { get; set; }

        [JsonProperty("user_uid")]
        public long UserUID { get; set; }
    }
}
