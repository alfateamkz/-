using Alfateam.Core;
using Alfateam.Messenger.Models.Accounts.Messengers;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using Alfateam.Messenger.Models.Stickers.External;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<AbsSticker>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamSticker), "AlfateamSticker")]
    [JsonKnownType(typeof(ExternalSticker), "ExternalSticker")]
    public class AbsSticker : AbsModel
    {
    }
}
