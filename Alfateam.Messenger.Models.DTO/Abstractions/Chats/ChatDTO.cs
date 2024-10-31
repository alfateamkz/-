using Alfateam.Messenger.Models.Abstractions.Chats;
using Alfateam.Messenger.Models.Chats.Alfateam;
using Alfateam.Messenger.Models.Chats;
using Alfateam.Messenger.Models.DTO.General.Chats;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Messenger.Models.DTO.Chats.Alfateam;
using Alfateam.Messenger.Models.DTO.Chats;
using Newtonsoft.Json;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Chats
{
    [JsonConverter(typeof(JsonKnownTypesConverter<ChatDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamMessengerChatDTO), "AlfateamMessengerChat")]
    [JsonKnownType(typeof(ExternalMessengerChatDTO), "ExternalMessengerChat")]

    [JsonKnownType(typeof(AlfateamGroupChatDTO), "AlfateamGroupChat")]
    [JsonKnownType(typeof(AlfateamPrivateChatDTO), "AlfateamPrivateChat")]
    [JsonKnownType(typeof(ExternalGroupChatDTO), "ExternalGroupChat")]
    [JsonKnownType(typeof(ExternalPrivateChatDTO), "ExternalPrivateChat")]
    public class ChatDTO : DTOModelAbs<Chat>
    {
        public ChatPersonalSettingsDTO UserPersonalSettings { get; set; }
    }
}
