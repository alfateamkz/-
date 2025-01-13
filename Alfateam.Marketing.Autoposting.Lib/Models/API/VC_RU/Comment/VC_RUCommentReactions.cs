using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Comment
{
    public class VC_RUCommentReactions
    {
        [JsonProperty("counters")]
        public List<VC_RUCommentReactionsCounter> Counters { get; set; } = new List<VC_RUCommentReactionsCounter>();

        [JsonProperty("reactionId")]
        public int ReactionId { get; set; }
    }
}
