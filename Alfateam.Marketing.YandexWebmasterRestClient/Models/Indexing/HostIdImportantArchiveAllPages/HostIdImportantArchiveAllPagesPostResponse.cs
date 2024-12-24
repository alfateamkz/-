using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantArchiveAllPages
{
    public class HostIdImportantArchiveAllPagesPostResponse
    {
        [JsonProperty("task_id")]
        public string TaskId { get; set; }
    }
}
