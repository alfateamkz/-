using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls.FindCallUploadingById
{
    public class FindCallUploadingByIdResponse
    {
        [JsonProperty("uploading")]
        public OfflineCallsUploading Uploading { get; set; }
    }
}
