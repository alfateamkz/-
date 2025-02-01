using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.MessageAttachments;
using Alfateam.Messenger.Models.MessageAttachments;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<MessageAttachmentBaseDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(FileMessageAttachmentDTO), "FileMessageAttachment")]
    [JsonKnownType(typeof(URLMessageAttachmentDTO), "URLMessageAttachment")]
    public class MessageAttachmentBaseDTO : DTOModelAbs<MessageAttachmentBase>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string? ExtMessageAttachmentId { get; set; }
    }
}
