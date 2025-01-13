using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Profile
{
    public class VC_RUProfileAvatar
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public VC_RUProfileAvatarData Data { get; set; }
    }
}
