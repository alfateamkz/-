using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData.Audio
{
    public class PostAudioBlockDataAudioData
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("audio_info")]
        public PostAudioBlockDataInfo AudioInfo { get; set; }
    }
}
