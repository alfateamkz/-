using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Comment
{
    public class VC_RUCommentAuthor
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("uri")]
        public string URI { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public VC_RUCommentAuthorAvatar Avatar { get; set; }

        [JsonProperty("badge")]
        public string Badge { get; set; }

        [JsonProperty("badgeId")]
        public string BadgeId { get; set; }

        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; }

        [JsonProperty("isPlus")]
        public bool IsPlus { get; set; }

        [JsonProperty("isOnline")]
        public bool IsOnline { get; set; }

        [JsonProperty("isFrozen")]
        public bool IsFrozen { get; set; }

        [JsonProperty("isRemovedByUserRequest")]
        public bool IsRemovedByUserRequest { get; set; }
    }
}
