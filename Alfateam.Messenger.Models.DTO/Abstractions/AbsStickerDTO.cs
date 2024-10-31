using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Stickers.Alfateam;
using Alfateam.Messenger.Models.DTO.Stickers.External;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using Alfateam.Messenger.Models.Stickers.External;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<AbsStickerDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamStickerDTO), "AlfateamSticker")]
    [JsonKnownType(typeof(ExternalStickerDTO), "ExternalSticker")]
    public class AbsStickerDTO : DTOModelAbs<AbsSticker>
    {
    }
}
