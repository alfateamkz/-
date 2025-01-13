using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post
{
    public class PostReactions
    {
        [JsonProperty("counters")]
        public List<PostReactionsCounter> Counters { get; set; } = new List<PostReactionsCounter>();

        [JsonProperty("reactionId")]
        public int ReactionId { get; set; }
    }
}
