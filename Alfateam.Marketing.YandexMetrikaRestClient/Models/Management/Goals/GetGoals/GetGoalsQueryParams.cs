using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GetGoals
{
    public class GetGoalsQueryParams
    {
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("useDeleted")]
        public bool UseDeleted { get; set; }
    }
}
