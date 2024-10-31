using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.StickerSets;
using Alfateam.Messenger.Models.StickerSets;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AbsStickerSetDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamStickersSetDTO), "AlfateamStickersSet")]
    [JsonKnownType(typeof(ExternalStickersSetDTO), "ExternalStickersSet")]
    public class AbsStickerSetDTO : DTOModelAbs<AbsStickerSet>
    {
    }
}
