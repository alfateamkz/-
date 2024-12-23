using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostSearchQueriesPopular
{
    public class HostSearchQueriesPopularResponse
    {
        [JsonProperty("queries")]
        public List<HostSearchQuery> Queries { get; set; } = new List<HostSearchQuery>();

        [JsonProperty("date_from")]
        public DateTime DateFrom { get; set; }

        [JsonProperty("date_to")]
        public DateTime DateTo { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
