using Alfateam.Website.API.Models.DTO.ContentItems;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Website.API.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ContentItemDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AudioContentItemDTO), "AudioContentItem")]
    [JsonKnownType(typeof(ImageContentItemDTO), "ImageContentItem")]
    [JsonKnownType(typeof(ImageSliderContentItemDTO), "ImageSliderContentItem")]
    [JsonKnownType(typeof(TextContentItemDTO), "TextContentItem")]
    [JsonKnownType(typeof(VideoContentItemDTO), "VideoContentItem")]
    public class ContentItemDTO : DTOModel<ContentItem>
    {
        public string Guid { get; set; }

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
