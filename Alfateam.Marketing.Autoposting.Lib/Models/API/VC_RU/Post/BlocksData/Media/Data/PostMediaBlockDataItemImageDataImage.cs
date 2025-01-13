using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData.Media.Data
{
    public class PostMediaBlockDataItemImageDataImage : PostMediaBlockDataItemImageData
    {
        [JsonProperty("base64preview")]
        public string Base64preview { get; set; }
    }
}
