using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General.Pages
{
    public class PageStartDate
    {
        [JsonProperty("day")]
        public uint Day { get; set; }

        [JsonProperty("month")]
        public uint Month { get; set; }

        [JsonProperty("year")]
        public uint Year { get; set; }
    }
}
