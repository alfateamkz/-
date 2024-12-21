using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.GetLastUploadings
{
    public class GetLastUploadingsQueryParams
    {
        [JsonProperty("datetime_offset")]
        public DateTime DatetimeOffset { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("source")]
        public UploadingMetaExternalUploadingSource Source { get; set; }
    }
}
