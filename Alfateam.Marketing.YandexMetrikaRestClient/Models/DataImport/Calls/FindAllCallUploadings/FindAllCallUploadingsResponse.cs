using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls.FindAllCallUploadings
{
    public class FindAllCallUploadingsResponse
    {
        [JsonProperty("uploadings")]
        public List<OfflineCallsUploading> Uploadings { get; set; } = new List<OfflineCallsUploading>();
    }
}
