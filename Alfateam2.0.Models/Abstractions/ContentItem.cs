using Alfateam.Core;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Promocodes;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Abstractions
{


    [JsonConverter(typeof(JsonKnownTypesConverter<ContentItem>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AudioContentItem), "AudioContentItem")]
    [JsonKnownType(typeof(ImageContentItem), "ImageContentItem")]
    [JsonKnownType(typeof(ImageSliderContentItem), "ImageSliderContentItem")]
    [JsonKnownType(typeof(TextContentItem), "TextContentItem")]
    [JsonKnownType(typeof(VideoContentItem), "VideoContentItem")]
    /// <summary>
    /// Сущность блока контента
    /// </summary>
    public class ContentItem : AbsModel
    {
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();

        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? ImageSliderContentItemId { get; set; }


        public virtual bool AreSame(ContentItem other)
        {
            if(this.GetType() != other.GetType()) return false;
            if(this.Guid != other.Guid) return false;
            if(this.Id != other.Id) return false;

            return true;
        }
    }
}
