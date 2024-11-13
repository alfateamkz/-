using Alfateam.Sales.API.Models.DTO.BusinessProposals.Placeholders;
using Alfateam.Sales.Models.Abstractions;
using Alfateam.Sales.Models.BusinessProposals.Placeholders;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Sales.API.Models.DTO.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<BPTemplatePlaceholderDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(BPCustomerTemplatePlaceholderDTO), "BPCustomerTemplatePlaceholder")]
    [JsonKnownType(typeof(BPManualTemplatePlaceholderDTO), "BPManualTemplatePlaceholder")]
    public class BPTemplatePlaceholderDTO : DTOModelAbs<BPTemplatePlaceholder>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string PlaceholderName { get; set; }
        public bool IsRequired { get; set; }
    }
}
