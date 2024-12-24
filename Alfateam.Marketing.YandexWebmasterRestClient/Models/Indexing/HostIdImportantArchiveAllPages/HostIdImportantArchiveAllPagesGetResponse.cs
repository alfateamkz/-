using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Indexing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantArchiveAllPages
{
    public class HostIdImportantArchiveAllPagesGetResponse
    {
        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [JsonProperty("state")]
        public ImportantArchiveTaskStatus State { get; set; }

        [JsonProperty("download_url")]
        public string DownloadURL { get; set; }
    }
}
