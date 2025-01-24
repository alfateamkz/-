using Alfateam.Administration.Models.StaticTextsConstructor;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<AbsField>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(HTMLTextField), "HTMLTextField")]
    [JsonKnownType(typeof(ImageField), "ImageField")]
    [JsonKnownType(typeof(SimpleTextField), "SimpleTextField")]
    [JsonKnownType(typeof(VideoField), "VideoField")]
    public class AbsField : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string FieldName { get; set; }
        public string Title { get; set; }
    }
}
