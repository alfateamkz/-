using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post
{
    public class PostAuthor
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("uri")]
        public string URI { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("avatar")]
        public PostAuthorAvatar Avatar { get; set; }

        [JsonProperty("cover")]
        public PostAuthorCover Cover { get; set; }

        [JsonProperty("badge")]
        public object Badge { get; set; }

        [JsonProperty("badgeId")]
        public string BadgeId { get; set; }

        [JsonProperty("isSubscribed")]
        public bool IsSubscribed { get; set; }

        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; }

        [JsonProperty("isCompany")]
        public bool IsCompany { get; set; }

        [JsonProperty("isPlus")]
        public bool IsPlus { get; set; }

        [JsonProperty("isDisabledAd")]
        public bool IsDisabledAd { get; set; }

        [JsonProperty("isPro")]
        public bool IsPro { get; set; }

        [JsonProperty("isUnverifiedBlogForCompanyWithoutPro")]
        public bool IsUnverifiedBlogForCompanyWithoutPro { get; set; }

        [JsonProperty("isOnline")]
        public bool IsOnline { get; set; }

        [JsonProperty("isMuted")]
        public bool IsMuted { get; set; }

        [JsonProperty("isUnsubscribable")]
        public bool IsUnsubscribable { get; set; }

        [JsonProperty("isSubscribedToNewPosts")]
        public bool IsSubscribedToNewPosts { get; set; }

        [JsonProperty("isEnabledCommentEditor")]
        public bool IsEnabledCommentEditor { get; set; }

        [JsonProperty("commentEditor")]
        public PostAuthorCommentEditor CommentEditor { get; set; }

        [JsonProperty("isAvailableForMessenger")]
        public bool IsAvailableForMessenger { get; set; }

        [JsonProperty("isFrozen")]
        public bool IsFrozen { get; set; }

        [JsonProperty("isRemovedByUserRequest")]
        public bool IsRemovedByUserRequest { get; set; }

        [JsonProperty("coverY")]
        public int CoverY { get; set; }

        [JsonProperty("lastModificationDate")]
        public int LastModificationDate { get; set; }

        [JsonProperty("isDonationsEnabled")]
        public bool IsDonationsEnabled { get; set; }

        [JsonProperty("yandexMetricaId")]
        public string YandexMetricaId { get; set; }

        [JsonProperty("ogTitle")]
        public string OgTitle { get; set; }

        [JsonProperty("ogDescription")]
        public string OgDescription { get; set; }

        [JsonProperty("isPlusGiftEnabled")]
        public bool IsPlusGiftEnabled { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("tgChannelShortname")]
        public string TgChannelShortname { get; set; }
    }
}
