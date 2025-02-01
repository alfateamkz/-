using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.DTO.Messages.SystemMessages;
using Alfateam.Messenger.Models.DTO.Messages.UserMessages;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Messenger.Models.Messages.SystemMessages;
using Alfateam.Messenger.Models.Messages.UserMessages;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<MessageBaseDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(SystemMessageDTO), "SystemMessage")]
    [JsonKnownType(typeof(UserMessageDTO), "UserMessage")]

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
    public class MessageBaseDTO : DTOModelAbs<MessageBase>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public string? ExtMessageId { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReadAt { get; set; }
        public ChatMessageDeletedInfo? DeletedInfo { get; set; }
    }
}
