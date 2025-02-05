using Alfateam.Telephony.API.Models.DTO.ExternalInteractions;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.ExternalInteractions;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Telephony.API.Models.DTO.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<ExtInteractionDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(CallbackExtInteractionDTO), "CallbackExtInteraction")]
    [JsonKnownType(typeof(CallUsExtInteractionDTO), "CallUsExtInteraction")]
    public class ExtInteractionDTO : DTOModelAbs<ExtInteraction>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        public string Title { get; set; }
    }
}
