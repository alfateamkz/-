using Alfateam.Core;
using Alfateam.Messenger.Models.Attachments.Alfateam;
using Alfateam.Messenger.Models.Attachments.External;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Attachments
{
    [JsonConverter(typeof(JsonKnownTypesConverter<MessageAttachment>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamMessageAttachment), "AlfateamMessageAttachment")]
    [JsonKnownType(typeof(ExternalMessageAttachment), "ExternalMessageAttachment")]

    [JsonKnownType(typeof(FileMessageAttachment), "FileMessageAttachment")]
    [JsonKnownType(typeof(ExtFileMessageAttachment), "ExtFileMessageAttachment")]
    public class MessageAttachment : AbsModel
    {
    }
}
