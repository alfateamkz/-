using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostSearchQueriesHistory
{
    public class HostSearchQueriesHistoryResponse
    {
        [JsonProperty("queries")]
        public List<HostSearchQuery> Queries { get; set; } = new List<HostSearchQuery>();   
    }
}
