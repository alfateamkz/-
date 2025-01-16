using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated
{
    public class BusinessAssetGroup
    {
        [JsonProperty("adaccount_tasks")]
        public List<string> AdAccountTasks { get; set; } = new List<string>();

        [JsonProperty("offline_conversion_data_set_tasks")]
        public List<string> OfflineConversionDataSetTasks { get; set; } = new List<string>();

        [JsonProperty("page_tasks")]
        public List<string> PageTasks { get; set; } = new List<string>();

        [JsonProperty("pixel_tasks")]
        public List<string> PixelTasks { get; set; } = new List<string>();
    }
}
