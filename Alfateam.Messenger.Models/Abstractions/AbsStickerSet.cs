using Alfateam.Core;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using Alfateam.Messenger.Models.Stickers.External;
using Alfateam.Messenger.Models.StickerSets;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AbsStickerSet>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamStickersSet), "AlfateamStickersSet")]
    [JsonKnownType(typeof(ExternalStickersSet), "ExternalStickersSet")]
    public class AbsStickerSet : AbsModel
    {
    }
}
