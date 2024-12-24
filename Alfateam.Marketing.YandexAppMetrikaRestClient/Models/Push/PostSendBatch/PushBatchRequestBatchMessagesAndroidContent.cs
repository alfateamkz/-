using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Push;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch
{
    public class PushBatchRequestBatchMessagesAndroidContent
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_background")]
        public string IconBackground { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("banner")]
        public string Banner { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("collapse_key")]
        public int CollapseKey { get; set; }

        [JsonProperty("vibration")]
        public List<int> Vibration { get; set; } = new List<int>();

        [JsonProperty("led_color")]
        public string LedColor { get; set; }

        [JsonProperty("led_interval")]
        public int LedInterval { get; set; }

        [JsonProperty("led_pause_interval")]
        public int LedPauseInterval { get; set; }

        [JsonProperty("time_to_live")]
        public int TimeToLive { get; set; }

        [JsonProperty("visibility")]
        public PushBatchRequestBatchMessagesAndroidContentVisibility Visibility { get; set; }

        [JsonProperty("urgency")]
        public PushBatchRequestBatchMessagesAndroidContentUrgency Urgency { get; set; }
    }
}
