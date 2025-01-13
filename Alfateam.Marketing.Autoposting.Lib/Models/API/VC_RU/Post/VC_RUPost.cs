using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post
{
    public class VC_RUPost : Alfateam.Marketing.Autoposting.Lib.Models.Posts.Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("author")]
        public PostAuthor Author { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("customUri")]
        public string CustomURI { get; set; }

        [JsonProperty("subsiteId")]
        public int SubsiteId { get; set; }

        [JsonProperty("subsite")]
        public PostSubsite Subsite { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("media")]
        public object Media { get; set; }

        [JsonProperty("date")]
        public int Date { get; set; }

        [JsonProperty("dateModified")]
        public int DateModified { get; set; }

        [JsonProperty("blocks")]
        public List<PostBlock> Blocks { get; set; } = new List<PostBlock>();

        [JsonProperty("warningFromEditor")]
        public object WarningFromEditor { get; set; }

        [JsonProperty("counters")]
        public PostCounters Counters { get; set; }

        [JsonProperty("commentsSeenCount")]
        public object CommentsSeenCount { get; set; }

        [JsonProperty("dateFavorite")]
        public int DateFavorite { get; set; }

        [JsonProperty("hitsCount")]
        public int HitsCount { get; set; }

        [JsonProperty("isCommentsEnabled")]
        public bool IsCommentsEnabled { get; set; }

        [JsonProperty("isLikesEnabled")]
        public bool IsLikesEnabled { get; set; }

        [JsonProperty("isRemovedByUserRequest")]
        public bool IsRemovedByUserRequest { get; set; }

        [JsonProperty("isFavorited")]
        public bool IsFavorited { get; set; }

        [JsonProperty("isRepost")]
        public bool IsRepost { get; set; }

        [JsonProperty("likes")]
        public PostLikes Likes { get; set; }

        [JsonProperty("reactions")]
        public PostReactions Reactions { get; set; }

        [JsonProperty("isPinned")]
        public bool IsPinned { get; set; }

        [JsonProperty("canEdit")]
        public bool CanEdit { get; set; }

        [JsonProperty("etcControls")]
        public PostEtcControls EtcControls { get; set; }

        [JsonProperty("repost")]
        public object Repost { get; set; }

        [JsonProperty("repostId")]
        public int? RepostId { get; set; }

        [JsonProperty("repostData")]
        public object RepostData { get; set; }

        [JsonProperty("isRepostedByMe")]
        public bool IsRepostedByMe { get; set; }

        [JsonProperty("stackedRepostsAuthors")]
        public List<object> StackedRepostsAuthors { get; set; } = new List<object>();

        [JsonProperty("subscribedToTreads")]
        public bool SubscribedToTreads { get; set; }

        [JsonProperty("isShowThanks")]
        public bool IsShowThanks { get; set; }

        [JsonProperty("isStillUpdating")]
        public bool IsStillUpdating { get; set; }

        [JsonProperty("isFilledByEditors")]
        public bool IsFilledByEditors { get; set; }

        [JsonProperty("isEditorial")]
        public bool IsEditorial { get; set; }

        [JsonProperty("recommendedType")]
        public string RecommendedType { get; set; }

        [JsonProperty("isAudioAvailable")]
        public bool IsAudioAvailable { get; set; }

        [JsonProperty("audioUrl")]
        public string AudioUrl { get; set; }

        [JsonProperty("commentEditor")]
        public PostCommentEditor CommentEditor { get; set; }

        [JsonProperty("coAuthor")]
        public object CoAuthor { get; set; }

        [JsonProperty("isBlur")]
        public bool IsBlur { get; set; }

        [JsonProperty("isPublished")]
        public bool IsPublished { get; set; }

        [JsonProperty("isDisabledAd")]
        public bool IsDisabledAd { get; set; }

        [JsonProperty("withheld")]
        public List<object> Withheld { get; set; } = new List<object>();

        [JsonProperty("robotsTag")]
        public object RobotsTag { get; set; }

        [JsonProperty("ogTitle")]
        public object OgTitle { get; set; }

        [JsonProperty("ogDescription")]
        public object OgDescription { get; set; }

        [JsonProperty("keywords")]
        public List<object> Keywords { get; set; } = new List<object>();

        [JsonProperty("isNews")]
        public bool IsNews { get; set; }

        [JsonProperty("source")]
        public object Source { get; set; }
    }
}
