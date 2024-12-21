using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Orders.UploadOrdersJSON
{
    public class UploadOrdersJSONQueryParams
    {
        [JsonProperty("merge_mode")]
        public MergeMode MergeMode { get; set; }
    }
}
