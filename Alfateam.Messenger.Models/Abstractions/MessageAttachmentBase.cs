using Alfateam.Core;
using Alfateam.Messenger.Models.General.GroupChats.Members;
using Alfateam.Messenger.Models.MessageAttachments;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<MessageAttachmentBase>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(FileMessageAttachment), "FileMessageAttachment")]
    [JsonKnownType(typeof(URLMessageAttachment), "URLMessageAttachment")]
    public class MessageAttachmentBase : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string? ExtMessageAttachmentId { get; set; }
    }
}
