using Alfateam.Administration.Models.Abstractions;
using Alfateam.Administration.Models.DTO.StaticTextsConstructor.Fields;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Administration.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AbsFieldDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(HTMLTextFieldDTO), "HTMLTextField")]
    [JsonKnownType(typeof(ImageFieldDTO), "ImageField")]
    [JsonKnownType(typeof(SimpleTextFieldDTO), "SimpleTextField")]
    [JsonKnownType(typeof(VideoFieldDTO), "VideoField")]
    public class AbsFieldDTO : DTOModelAbs<AbsField>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string FieldName { get; set; }
        public string Title { get; set; }
    }
}
