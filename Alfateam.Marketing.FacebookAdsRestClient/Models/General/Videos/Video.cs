using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General.Videos
{
    public class Video
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ad_breaks")]
        public List<int> AdBreaks { get; set; } = new List<int>();

        [JsonProperty("backdated_time")]
        public DateTime BackdatedTime { get; set; }

        [JsonProperty("backdated_time_granularity")]
        public BackdatedTimeGranularity BackdatedTimeGranularity { get; set; }

        [JsonProperty("boost_eligibility_info")]
        public VideoBoostEligibilityInfo BoostEligibilityInfo { get; set; }

        [JsonProperty("content_category")]
        public VideoContentCategory ContentCategory { get; set; }

        [JsonProperty("content_tags")]
        public List<long> ContentTags { get; set; } = new List<long>();

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("custom_labels")]
        public List<string> CustomLabels { get; set; } = new List<string>();

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("embed_html")]
        public IFrameWithSrc EmbedHTML { get; set; }

        [JsonProperty("embeddable")]
        public bool Embeddable { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("format")]
        public List<VideoFormat> Format { get; set; } = new List<VideoFormat>();

        [JsonProperty("from")]
        public object From { get; set; } //TODO: User|Page

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("is_crosspost_video")]
        public bool IsCrosspostVideo { get; set; }

        [JsonProperty("is_crossposting_eligible")]
        public bool IsCrosspostingEligible { get; set; }

        [JsonProperty("is_episode")]
        public bool IsEpisode { get; set; }

        [JsonProperty("is_instagram_eligible")]
        public bool IsInstagramEligible { get; set; }

        [JsonProperty("is_reference_only")]
        public bool IsReferenceOnly { get; set; }

        [JsonProperty("length")]
        public float Length { get; set; }

        [JsonProperty("live_status")]
        public VideoLifeStatus LiveStatus { get; set; }

        [JsonProperty("music_video_copyright")]
        public MusicVideoCopyright MusicVideoCopyright { get; set; }

        [JsonProperty("permalink_url")]
        public string PermalinkURL { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }

        [JsonProperty("post_id")]
        public long PostId { get; set; }

        [JsonProperty("post_views")]
        public uint PostViews { get; set; }

        [JsonProperty("premiere_living_room_status")]
        public VideoPremiereLivingRoomStatus PremiereLivingRoomStatus { get; set; }

        [JsonProperty("privacy")]
        public Privacy Privacy { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("scheduled_publish_time")]
        public DateTime ScheduledPublishTime { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("status")]
        public VideoStatus Satus { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("universal_video_id")]
        public string UniversalVideoId { get; set; }

        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        [JsonProperty("views")]
        public uint Views { get; set; }
    }
}
