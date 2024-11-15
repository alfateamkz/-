using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.ExternalInteractions;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.ExternalInteractions;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions.ExtInterations
{

    [JsonConverter(typeof(JsonKnownTypesConverter<ExternalInteractionDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CommunitationButtonsExtInterationDTO), "CommunitationButtonsExtInteration")]
    [JsonKnownType(typeof(WebsiteFormExtInterationDTO), "WebsiteFormExtInteration")]
    public class ExternalInteractionDTO : DTOModelAbs<ExternalInteraction>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [ForClientOnly]
        public string UniqueIntegrationURL { get; set; } 
        public string Title { get; set; }
    }
}
