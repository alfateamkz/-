using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.UserParams
{
    public class UserParamsUploading
    {
        [JsonProperty("action")]
        public UserParamsUploadingAction Action { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("content_id_type")]
        public ContentIdType ContentIdType { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("line_quantity")]
        public int LineQuantity { get; set; }

        [JsonProperty("status")]
        public UserParamsUploadingStatus Status { get; set; }
    }
}
