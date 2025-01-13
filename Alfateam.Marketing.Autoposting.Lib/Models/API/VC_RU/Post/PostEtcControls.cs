using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post
{
    public class PostEtcControls
    {
        [JsonProperty("editEntry")]
        public bool EditEntry { get; set; }

        [JsonProperty("pinContent")]
        public bool PinContent { get; set; }

        [JsonProperty("unpublishEntry")]
        public bool UnpublishEntry { get; set; }
    }
}
