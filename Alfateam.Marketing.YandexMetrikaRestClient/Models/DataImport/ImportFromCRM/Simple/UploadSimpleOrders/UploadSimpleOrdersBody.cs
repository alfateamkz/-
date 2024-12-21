using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Simple.UploadSimpleOrders
{
    public class UploadSimpleOrdersBody
    {
        [JsonProperty("file")]
        public byte[] File { get; set; }
    }
}
