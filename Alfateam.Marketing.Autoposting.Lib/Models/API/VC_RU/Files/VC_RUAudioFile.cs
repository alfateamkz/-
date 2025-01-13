using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.FileUpload.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Files
{
    public class VC_RUAudioFile : VC_RUFile
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("audio_info")]
        public VC_RUAudioFileData AudioInfo { get; set; }
    }
}
