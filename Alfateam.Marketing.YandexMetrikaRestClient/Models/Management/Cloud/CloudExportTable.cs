using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Cloud;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Cloud
{
    public class CloudExportTable
    {
        [JsonProperty("ce_id")]
        public int CEID { get; set; }

        [JsonProperty("columns")]
        public List<string> Columns { get; set; } = new List<string>();

        [JsonProperty("statistics")]
        public CloudExportStatistics Statistics { get; set; }

        [JsonProperty("status")]
        public CloudExportTableStatus Status { get; set; }

        [JsonProperty("table_name")]
        public CloudExportTableName TableName { get; set; }
    }
}
