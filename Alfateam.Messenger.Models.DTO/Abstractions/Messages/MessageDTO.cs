using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.Alfateam;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.External;
using Alfateam.Messenger.Models.DTO.Messages.Alfateam.SystemMessages;
using Alfateam.Messenger.Models.DTO.Messages.Alfateam.UserMessages;
using Alfateam.Messenger.Models.DTO.Messages.External.SystemMessages;
using Alfateam.Messenger.Models.DTO.Messages.External.UserMessages;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Messages
{

    [JsonConverter(typeof(JsonKnownTypesConverter<MessageDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamMessengerMessageDTO), "AlfateamMessengerMessage")]
    [JsonKnownType(typeof(AlfateamMessengerUserMessageDTO), "AlfateamMessengerUserMessage")]
    [JsonKnownType(typeof(AlfateamMessengerSystemMessageDTO), "AlfateamMessengerSystemMessage")]

    [JsonKnownType(typeof(ExternalMessengerMessageDTO), "ExternalMessengerMessage")]
    [JsonKnownType(typeof(ExternalMessengerUserMessageDTO), "ExternalMessengerUserMessage")]
    [JsonKnownType(typeof(ExternalMessengerSystemMessageDTO), "ExternalMessengerSystemMessage")]

    [JsonKnownType(typeof(ChatPhotoChangedMessageDTO), "ChatPhotoChangedMessage")]
    [JsonKnownType(typeof(ChatTitleChangedMessageDTO), "ChatTitleChangedMessage")]
    [JsonKnownType(typeof(GroupChatCreatedMessageDTO), "GroupChatCreatedMessage")]
    [JsonKnownType(typeof(JoinedUserMessageDTO), "JoinedUserMessage")]
    [JsonKnownType(typeof(KickedUserMessageDTO), "KickedUserMessage")]
    [JsonKnownType(typeof(PinnedSystemMessageDTO), "PinnedSystemMessage")]

    [JsonKnownType(typeof(ContactMessageDTO), "ContactMessage")]
    [JsonKnownType(typeof(LocationMessageDTO), "LocationMessage")]
    [JsonKnownType(typeof(StickerMessageDTO), "StickerMessage")]
    [JsonKnownType(typeof(TextMessageDTO), "TextMessage")]
    [JsonKnownType(typeof(VoiceMessageDTO), "VoiceMessage")]

    [JsonKnownType(typeof(ExtChatPhotoChangedMessageDTO), "ExtChatPhotoChangedMessage")]
    [JsonKnownType(typeof(ExtChatTitleChangedMessageDTO), "ExtChatTitleChangedMessage")]
    [JsonKnownType(typeof(ExtGroupChatCreatedMessageDTO), "ExtGroupChatCreatedMessage")]
    [JsonKnownType(typeof(ExtJoinedUserMessageDTO), "ExtJoinedUserMessage")]
    [JsonKnownType(typeof(ExtKickedUserMessageDTO), "ExtKickedUserMessage")]
    [JsonKnownType(typeof(ExtPinnedSystemMessageDTO), "ExtPinnedSystemMessage")]

    [JsonKnownType(typeof(ExtContactMessageDTO), "ExtContactMessage")]
    [JsonKnownType(typeof(ExtLocationMessageDTO), "ExtLocationMessage")]
    [JsonKnownType(typeof(ExtStickerMessageDTO), "ExtStickerMessage")]
    [JsonKnownType(typeof(ExtTextMessageDTO), "ExtTextMessage")]
    [JsonKnownType(typeof(ExtVoiceMessageDTO), "ExtVoiceMessage")]
    public class MessageDTO : DTOModelAbs<Message>
    {
   
    }
}
