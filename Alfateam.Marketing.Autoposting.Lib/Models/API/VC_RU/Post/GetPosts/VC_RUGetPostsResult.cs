using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Comment;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post.GetPosts
{
    public class VC_RUGetPostsResult
    {
        [JsonProperty("items")]
        public List<VC_RUGetPostsResultItem> Items { get; set; } = new List<VC_RUGetPostsResultItem>();
    }
}
