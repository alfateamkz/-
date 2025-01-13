using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData.Audio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData
{
    public class PostAudioBlockData : PostBlockData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("image")]
        public object Image { get; set; }

        [JsonProperty("audio")]
        public PostAudioBlockDataAudio Audio { get; set; }

        [JsonProperty("listensCount")]
        public object ListensCount { get; set; }
    }
}
