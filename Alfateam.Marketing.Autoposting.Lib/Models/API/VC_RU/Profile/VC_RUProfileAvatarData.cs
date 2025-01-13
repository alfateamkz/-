using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Profile
{
    public class VC_RUProfileAvatarData
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
        public List<object> ExternalService { get; set; } = new List<object>();

        [JsonProperty("hash")]
        public string Base64preview { get; set; }
    }
}
