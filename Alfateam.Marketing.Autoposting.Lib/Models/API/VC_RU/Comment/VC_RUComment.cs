using Alfateam.Marketing.Autoposting.Lib.Models.Comments;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Comment
{
    public class VC_RUComment : Alfateam.Marketing.Autoposting.Lib.Models.Comments.Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("author")]
        public VC_RUCommentAuthor Author { get; set; }

        [JsonProperty("date")]
        public int Date { get; set; }

        [JsonProperty("lastModificationDate")]
        public int LastModificationDate { get; set; }

        [JsonProperty("isFavorited")]
        public bool IsFavorited { get; set; }

        [JsonProperty("dateFavorite")]
        public int DateFavorite { get; set; }

        [JsonProperty("isEdited")]
        public bool IsEdited { get; set; }

        [JsonProperty("likes")]
        public VC_RUCommentLikes Likes { get; set; }

        [JsonProperty("reactions")]
        public VC_RUCommentReactions Reactions { get; set; }

        [JsonProperty("entry")]
        public VC_RUCommentEntry Entry { get; set; }

        [JsonProperty("media")]
        public object Media { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("isPinned")]
        public bool IsPinned { get; set; }

        [JsonProperty("isIgnored")]
        public bool IsIgnored { get; set; }

        [JsonProperty("isRemoved")]
        public bool IsRemoved { get; set; }

        [JsonProperty("isRemovedByModerator")]
        public bool IsRemovedByModerator { get; set; }

        [JsonProperty("replyTo")]
        public int ReplyTo { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("donation")]
        public int Donation { get; set; }

        [JsonProperty("donate")]
        public object Donate { get; set; }

        [JsonProperty("threadId")]
        public string ThreadId { get; set; }

        [JsonProperty("replyCount")]
        public int ReplyCount { get; set; }
    }
}
