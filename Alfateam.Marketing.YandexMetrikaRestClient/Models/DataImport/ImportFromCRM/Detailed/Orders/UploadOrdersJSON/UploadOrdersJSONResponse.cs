using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Orders.UploadOrdersJSON
{
    public class UploadOrdersJSONResponse
    {
        [JsonProperty("uploading")]
        public UploadingMetaExternal Uploading { get; set; }
    }
}
