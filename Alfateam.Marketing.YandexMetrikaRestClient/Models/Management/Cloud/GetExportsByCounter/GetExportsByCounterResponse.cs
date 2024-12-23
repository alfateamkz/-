using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Cloud.GetExportsByCounter
{
    public class GetExportsByCounterResponse
    {
        [JsonProperty("cloud_exports")]
        public List<CloudExport> CloudExports { get; set; } = new List<CloudExport>();
    }
}
