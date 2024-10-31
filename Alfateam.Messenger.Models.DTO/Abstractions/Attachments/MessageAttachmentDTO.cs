using Alfateam.Messenger.Models.Abstractions.Attachments;
using Alfateam.Messenger.Models.Attachments;
using Alfateam.Messenger.Models.DTO.Attachments;
using Alfateam.Messenger.Models.DTO.Attachments.Alfateam;
using Alfateam.Messenger.Models.DTO.Attachments.External;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Attachments
{
    [JsonConverter(typeof(JsonKnownTypesConverter<MessageAttachmentDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamMessageAttachmentDTO), "AlfateamMessageAttachment")]
    [JsonKnownType(typeof(ExternalMessageAttachmentDTO), "ExternalMessageAttachment")]

    [JsonKnownType(typeof(FileMessageAttachmentDTO), "FileMessageAttachment")]
    [JsonKnownType(typeof(ExtFileMessageAttachmentDTO), "ExtFileMessageAttachment")]
    public class MessageAttachmentDTO : DTOModelAbs<AlfateamMessageAttachment>
    {
    }
}
