using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post;
using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.BlocksData
{
    public class PostMediaBlockData : PostBlockData
    {
        [JsonProperty("items")]
        public List<PostMediaBlockDataItem> Items { get; set; } = new List<PostMediaBlockDataItem>();
    }
}
