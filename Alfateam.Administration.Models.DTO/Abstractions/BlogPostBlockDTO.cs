using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.Blogs.Blocks;
using Alfateam.Administration.Models.DTO.Blogs.Blocks;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Administration.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<BlogPostBlockDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AudioBlockDTO), "AudioBlock")]
    [JsonKnownType(typeof(DelimiterBlockDTO), "DelimiterBlock")]
    [JsonKnownType(typeof(HTMLTextBlockDTO), "HTMLTextBlock")]
    [JsonKnownType(typeof(ImageBlockDTO), "ImageBlock")]
    [JsonKnownType(typeof(QuoteBlockDTO), "QuoteBlock")]
    [JsonKnownType(typeof(VideoBlockDTO), "VideoBlock")]
    public class BlogPostBlockDTO : DTOModelAbs<BlogPostBlock>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
