using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions.FindAllConversions
{
    public class FindAllConversionsResponse
    {
        [JsonProperty("uploadings")]
        public List<OfflineConversionUploading> Uploadings { get; set; } = new List<OfflineConversionUploading>();
    }
}
