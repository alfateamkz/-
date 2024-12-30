using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions
{
    public class WithOfflineConversionUploadingResponse
    {
        [JsonProperty("uploading")]
        public OfflineConversionUploading Uploading { get; set; }
    }
}
