using Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Post;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Autoposting.Lib.Models.API.VC_RU.Profile
{
    public class VC_RUProfile : Alfateam.Marketing.Autoposting.Lib.Models.Profile
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
        public VC_RUProfileAvatar Avatar { get; set; }

        [JsonProperty("cover")]
        public VC_RUProfileCover Cover { get; set; }

        [JsonProperty("badge")]
        public object Badge { get; set; }

        [JsonProperty("badgeId")]
        public string BadgeId { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("hashtags")]
        public object Hashtags { get; set; }

        [JsonProperty("isSubscribed")]
        public bool IsSubscribed { get; set; }

        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; }

        [JsonProperty("isCompany")]
        public bool IsCompany { get; set; }

        [JsonProperty("isDisabledAd")]
        public bool IsDisabledAd { get; set; }

        [JsonProperty("isOnline")]
        public bool IsOnline { get; set; }

        [JsonProperty("isMuted")]
        public bool IsMuted { get; set; }

        [JsonProperty("isUnsubscribable")]
        public bool IsUnsubscribable { get; set; }

        [JsonProperty("isEnableWriting")]
        public bool IsEnableWriting { get; set; }

        [JsonProperty("isSubscribedToNewPosts")]
        public bool IsSubscribedToNewPosts { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("contacts")]
        public VC_RUProfileContacts Contacts { get; set; }

        [JsonProperty("commentEditor")]
        public VC_RUProfileCommentEditor CommentEditor { get; set; }

        [JsonProperty("isAvailableForMessenger")]
        public bool IsAvailableForMessenger { get; set; }

        [JsonProperty("isPlus")]
        public bool IsPlus { get; set; }

        [JsonProperty("isPro")]
        public bool IsPro { get; set; }

        [JsonProperty("isUnverifiedBlogForCompanyWithoutPro")]
        public bool IsUnverifiedBlogForCompanyWithoutPro { get; set; }

        [JsonProperty("isFrozen")]
        public bool IsFrozen { get; set; }

        [JsonProperty("isRemovedByUserRequest")]
        public bool IsRemovedByUserRequest { get; set; }

        [JsonProperty("coverY")]
        public int CoverY { get; set; }

        [JsonProperty("lastModificationDate")]
        public int LastModificationDate { get; set; }

        [JsonProperty("robotsTag")]
        public string RobotsTag { get; set; }

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

        [JsonProperty("counters")]
        public VC_RUProfileCounters Counters { get; set; }

        [JsonProperty("threeSubscribers")]
        public object ThreeSubscribers { get; set; }

        [JsonProperty("threeSubscriptions")]
        public object ThreeSubscriptions { get; set; }

        [JsonProperty("mHash")]
        public string MHash { get; set; }

        [JsonProperty("mHashExpirationTime")]
        public int MHashExpirationTime { get; set; }

        [JsonProperty("userHash")]
        public string UserHash { get; set; }

        [JsonProperty("userHashes")]
        public List<object> UserHashes { get; set; } = new List<object>();

        [JsonProperty("canChangeAvatar")]
        public bool CanChangeAvatar { get; set; }

        [JsonProperty("canChangeCover")]
        public bool CanChangeCover { get; set; }

        [JsonProperty("isBanned")]
        public bool IsBanned { get; set; }

        [JsonProperty("pushTopic")]
        public string PushTopic { get; set; }

        [JsonProperty("bannedInfo")]
        public object BannedInfo { get; set; }

        [JsonProperty("isSubsitesTuned")]
        public bool IsSubsitesTuned { get; set; }

        [JsonProperty("isAdult")]
        public bool IsAdult { get; set; }

        [JsonProperty("isBlurNsfw")]
        public bool IsBlurNsfw { get; set; }

        [JsonProperty("hidePromoBlocks")]
        public bool HidePromoBlocks { get; set; }

        [JsonProperty("isNameWasChanged")]
        public bool IsNameWasChanged { get; set; }

        [JsonProperty("nameChangeNextDate")]
        public int NameChangeNextDate { get; set; }

        [JsonProperty("isManagingSubsites")]
        public bool IsManagingSubsites { get; set; }

        [JsonProperty("defaultFeed")]
        public string DefaultFeed { get; set; }

        [JsonProperty("myFeedSorting")]
        public string MyFeedSorting { get; set; }

        [JsonProperty("aclGroup")]
        public int ACLGroup { get; set; }

        [JsonProperty("rank")]
        public object Rank { get; set; }
    }
}
