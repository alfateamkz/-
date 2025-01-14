using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeLinkDataImageLayerSpec
    {
        [JsonProperty("blending_mode")]
        public BlendingMode BlendingMode { get; set; }

        [JsonProperty("content")]
        public AdCreativeLinkDataImageTextOverlayContent Content { get; set; }

        [JsonProperty("frame_auto_show_enroll_status")]
        public FrameAutoShowEnrollStatus FrameAutoShowEnrollStatus { get; set; }

        [JsonProperty("frame_image_hash")]
        public string FrameImageHash { get; set; }

        [JsonProperty("frame_source")]
        public FrameSource FrameSource { get; set; }

        [JsonProperty("image_source")]
        public ImageSource ImageSource { get; set; }

        [JsonProperty("layer_type")]
        public LayerType LayerType { get; set; }

        [JsonProperty("opacity")]
        public int Opacity { get; set; }

        [JsonProperty("overlay_position")]
        public OverlayPosition OverlayPosition { get; set; }

        [JsonProperty("overlay_shape")]
        public OverlayShape OverlayShape { get; set; }

        [JsonProperty("scale")]
        public int Scale { get; set; }

        [JsonProperty("shape_color")]
        public string ShapeColor { get; set; }

        [JsonProperty("text_color")]
        public string TextColor { get; set; }

        [JsonProperty("text_font")]
        public TextFont TextFont { get; set; }
    }
}
