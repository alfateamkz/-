using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Chats;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Messenger.Models.Peers;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ChatBase>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(GroupChat), "GroupChat")]
    [JsonKnownType(typeof(PrivateChat), "PrivateChat")]
    public class ChatBase : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public string? ExtChatId { get; set; }
        public List<MessageBase> Messages { get; set; } = new List<MessageBase>();



        public List<ChatPersonalSettings> PersonalSettings { get; set; } = new List<ChatPersonalSettings>();
    }
}
