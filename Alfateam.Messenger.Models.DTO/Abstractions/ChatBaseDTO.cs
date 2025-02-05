using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Chats;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<ChatBaseDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(GroupChatDTO), "GroupChat")]
    [JsonKnownType(typeof(PrivateChatDTO), "PrivateChat")]
    public class ChatBaseDTO : DTOModelAbs<ChatBase>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [ForClientOnly]
        public string? ExtChatId { get; set; }
    }
}
