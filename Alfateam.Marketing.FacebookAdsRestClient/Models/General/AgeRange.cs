using Alfateam.Marketing.FacebookAdsRestClient.Enums.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class AgeRange
    {
        [JsonProperty("max")]
        public AgeRangeMaxEnum Max { get; set; }

        [JsonProperty("min")]
        public AgeRangeMinEnum Min { get; set; }
    }
}
