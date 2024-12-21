using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions.FindConversionUploadingById
{
    public class FindConversionUploadingByIdResponse
    {
        [JsonProperty("uploading")]
        public OfflineConversionUploading Uploading { get; set; }
    }
}
