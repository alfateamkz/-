using Alfateam.Administration.Models.Blogs.Blocks;
using Alfateam.Administration.Models.General.RolePowers;
using Alfateam.Core;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Administration.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<BlogPostBlock>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AudioBlock), "AudioBlock")]
    [JsonKnownType(typeof(DelimiterBlock), "DelimiterBlock")]
    [JsonKnownType(typeof(HTMLTextBlock), "HTMLTextBlock")]
    [JsonKnownType(typeof(ImageBlock), "ImageBlock")]
    [JsonKnownType(typeof(QuoteBlock), "QuoteBlock")]
    [JsonKnownType(typeof(VideoBlock), "VideoBlock")]
    public class BlogPostBlock : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
