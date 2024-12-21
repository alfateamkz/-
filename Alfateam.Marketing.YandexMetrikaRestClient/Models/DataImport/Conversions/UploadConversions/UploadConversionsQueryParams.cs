using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions.UploadConversions
{
    public class UploadConversionsQueryParams
    {
        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}
