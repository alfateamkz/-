using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdsInsights;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdsInsights
{
    public class AdsActionStats
    {
        [JsonProperty("1d_click")]
        public long _1DClick { get; set; }

        [JsonProperty("1d_click_all_conversions")]
        public long _1DClickAllConversions { get; set; }

        [JsonProperty("1d_click_first_conversion")]
        public long _1DClickFirstConversion { get; set; }

        [JsonProperty("1d_ev")]
        public long _1DEV { get; set; }

        [JsonProperty("1d_ev_all_conversions")]
        public long _1DEVAllConversions { get; set; }

        [JsonProperty("1d_ev_first_conversion")]
        public long _1DEVFirstConversion { get; set; }

        [JsonProperty("1d_view")]
        public long _1DView { get; set; }

        [JsonProperty("1d_view_all_conversions")]
        public long _1DViewAllConversions { get; set; }

        [JsonProperty("1d_view_first_conversion")]
        public long _1DViewFirstConversion { get; set; }

        [JsonProperty("28d_click")]
        public long _28DClick { get; set; }

        [JsonProperty("28d_click_all_conversions")]
        public long _28DClickAllConversions { get; set; }

        [JsonProperty("28d_click_first_conversion")]
        public long _28DClickFirstConversion { get; set; }

        [JsonProperty("28d_view")]
        public long _28DView { get; set; }

        [JsonProperty("28d_view_all_conversions")]
        public long _28DViewAllConversions { get; set; }

        [JsonProperty("28d_view_first_conversion")]
        public long _28DViewFirstConversion { get; set; }

        [JsonProperty("7d_click")]
        public long _7DClick { get; set; }

        [JsonProperty("7d_click_all_conversions")]
        public long _7DClickAllConversions { get; set; }

        [JsonProperty("7d_click_first_conversion")]
        public long _7DClickFirstConversion { get; set; }

        [JsonProperty("7d_view")]
        public long _7DView { get; set; }

        [JsonProperty("7d_view_all_conversions")]
        public long _7DViewAllConversions { get; set; }

        [JsonProperty("7d_view_first_conversion")]
        public long _7DViewFirstConversion { get; set; }

        [JsonProperty("action_canvas_component_name")]
        public string ActionCanvasComponentName { get; set; }

        [JsonProperty("action_carousel_card_id")]
        public string ActionCarouselCardId { get; set; }

        [JsonProperty("action_carousel_card_name")]
        public string ActionCarouselCardName { get; set; }

        [JsonProperty("action_destination")]
        public string ActionDestination { get; set; }

        [JsonProperty("action_device")]
        public AdsActionStatsActionDevice ActionDevice { get; set; }

        [JsonProperty("action_reaction")]
        public string ActionReaction { get; set; }

        [JsonProperty("action_target_id")]
        public string ActionTargetTd { get; set; }

        /// <summary>
        /// See https://developers.facebook.com/docs/marketing-api/reference/ads-action-stats/
        /// </summary>
        [JsonProperty("action_type")]
        public string ActionType { get; set; }

        [JsonProperty("action_video_sound")]
        public string ActionVideoSound { get; set; }

        [JsonProperty("action_video_type")]
        public string ActionVideoType { get; set; }

        [JsonProperty("dda")]
        public long DDA { get; set; }

        [JsonProperty("inline")]
        public long Inline { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
