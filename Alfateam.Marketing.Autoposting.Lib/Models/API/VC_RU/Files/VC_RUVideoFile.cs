using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Files
{
    public class VC_RUVideoFile : VC_RUFile
    {
        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("external_service")]
        public object ExternalService { get; set; }

        [JsonProperty("hash")]
        public string Base64preview { get; set; }

        [JsonProperty("isVideo")]
        public bool IsVideo { get; set; }

        [JsonProperty("duration")]
        public double? Duration { get; set; }
    }
}
