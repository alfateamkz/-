using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.Forms;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Shop.ProductModifierItems;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Forms;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.Website.API.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ProductModifierItemDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ContactMeFormDTO), "ContactMeForm")]
    [JsonKnownType(typeof(JoinEventFormDTO), "JoinEventForm")]
    public class SentFromWebsiteFormDTO : DTOModel<SentFromWebsiteForm>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }

        [ForClientOnly]
        public SentFromWebsiteFormHandlingStatus Status { get; set; }

        public string UserAgent { get; set; }
        public string Fingerprint { get; set; }

        [ForClientOnly]
        public string IP { get; set; }


        [ForClientOnly]
        public UserDTO? SentByUser { get; set; }
    }
}
