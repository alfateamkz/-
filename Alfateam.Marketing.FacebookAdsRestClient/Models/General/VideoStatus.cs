using Alfateam.Marketing.FacebookAdsRestClient.Enums.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class VideoStatus
    {
        [JsonProperty("processing_progress")]
        public uint ProcessingProgress { get; set; }

        [JsonProperty("video_status")]
        public VideoStatusEnum VideoStatusEnum { get; set; }
    }
}
