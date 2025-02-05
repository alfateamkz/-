using Alfateam.Sales.API.Models.DTO.ExternalInteractions.Inputs;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.ExternalInteractions.Inputs;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations
{
    [JsonConverter(typeof(JsonKnownTypesConverter<WebsiteFormInputDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CheckBoxWebsiteFormInputDTO), "CheckBoxWebsiteFormInput")]
    [JsonKnownType(typeof(NumberWebsiteFormInputDTO), "NumberWebsiteFormInput")]
    [JsonKnownType(typeof(RadioWebsiteFormInputDTO), "RadioWebsiteFormInput")]
    [JsonKnownType(typeof(RangeWebsiteFormInputDTO), "RangeWebsiteFormInput")]
    [JsonKnownType(typeof(TextWebsiteFormInputDTO), "TextWebsiteFormInput")]
    [JsonKnownType(typeof(FileWebsiteFormInputDTO), "FileWebsiteFormInput")]
    public class WebsiteFormInputDTO : DTOModelAbs<WebsiteFormInput>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }
        public string Placeholder { get; set; }


        public string FieldName { get; set; }


        public bool IsRequired { get; set; }
    }
}
