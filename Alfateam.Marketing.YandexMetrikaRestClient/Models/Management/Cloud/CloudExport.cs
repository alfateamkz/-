using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Cloud;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Cloud
{
    public class CloudExport
    {
        [JsonProperty("folder_id")]
        public string FolderId { get; set; }

        [JsonProperty("transfer_id")]
        public string TransferId { get; set; }

        [JsonProperty("ce_id")]
        public int CEID { get; set; }

        [JsonProperty("quota")]
        public long Quota { get; set; }

        [JsonProperty("status")]
        public CloudExportStatus Status { get; set; }
    }
}
