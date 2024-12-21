using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.GetLastUploadings
{
    public class GetLastUploadingsResponse
    {
        [JsonProperty("uploadings")]
        public List<UploadingMetaExternal> Uploadings { get; set; } = new List<UploadingMetaExternal>();
    }
}
