using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeLinkDataImageOverlaySpec
    {
        [JsonProperty("custom_text_type")]
        public CustomTextType CustomTextType { get; set; }

        [JsonProperty("float_with_margin")]
        public bool FloatWithMargin { get; set; }

        [JsonProperty("overlay_template")]
        public OverlayTemplate OverlayTemplate { get; set; }

        [JsonProperty("position")]
        public OverlayCornerPosition Position { get; set; }

        [JsonProperty("text_font")]
        public TextFont TextFont { get; set; }

        [JsonProperty("text_template_tags")]
        public List<string> TextTemplateTags { get; set; } = new List<string>();

        [JsonProperty("text_type")]
        public TextType TextType { get; set; }

        [JsonProperty("theme_color")]
        public ThemeColor ThemeColor { get; set; }
    }
}
