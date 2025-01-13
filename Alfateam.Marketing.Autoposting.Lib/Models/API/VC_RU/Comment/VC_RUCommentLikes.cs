using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Comment
{
    public class VC_RUCommentLikes
    {
        [JsonProperty("counterLikes")]
        public int CounterLikes { get; set; }

        [JsonProperty("counterDislikes")]
        public int? CounterDislikes { get; set; }

        [JsonProperty("isLiked")]
        public bool IsLiked { get; set; }

        [JsonProperty("isHidden")]
        public bool IsHidden { get; set; }
    }
}
