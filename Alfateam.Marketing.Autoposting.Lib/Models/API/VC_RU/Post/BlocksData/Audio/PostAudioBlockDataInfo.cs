using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData.Audio
{
    public class PostAudioBlockDataInfo
    {
        [JsonProperty("bitrate")]
        public int Bitrate { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("framesCount")]
        public int FramesCount { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("listens_count")]
        public int ListensCount { get; set; }
    }
}
