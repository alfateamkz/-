using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class VideoUploadLimits
    {
        [JsonProperty("length")]
        public uint Length { get; set; }

        [JsonProperty("size")]
        public uint Size { get; set; }
    }
}
