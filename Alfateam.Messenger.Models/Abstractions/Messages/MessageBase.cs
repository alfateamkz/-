using Alfateam.Core;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Messenger.Models.General.Chats.OfflineAutoTime;
using Alfateam.Messenger.Models.Messages.SystemMessages;
using Alfateam.Messenger.Models.Messages.UserMessages;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Messages
{
    [JsonConverter(typeof(JsonKnownTypesConverter<MessageBase>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(SystemMessage), "SystemMessage")]
    [JsonKnownType(typeof(UserMessage), "UserMessage")]

    [JsonKnownType(typeof(ChatPhotoChangedMessage), "ChatPhotoChangedMessage")]
    [JsonKnownType(typeof(ChatTitleChangedMessage), "ChatTitleChangedMessage")]
    [JsonKnownType(typeof(GroupChatCreatedMessage), "GroupChatCreatedMessage")]
    [JsonKnownType(typeof(JoinedUserMessage), "JoinedUserMessage")]
    [JsonKnownType(typeof(KickedUserMessage), "KickedUserMessage")]
    [JsonKnownType(typeof(PinnedSystemMessage), "PinnedSystemMessage")]

    [JsonKnownType(typeof(ContactMessage), "ContactMessage")]
    [JsonKnownType(typeof(LocationMessage), "LocationMessage")]
    [JsonKnownType(typeof(StickerMessage), "StickerMessage")]
    [JsonKnownType(typeof(TextMessage), "TextMessage")]
    [JsonKnownType(typeof(VoiceMessage), "VoiceMessage")]
    public class MessageBase : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public string? ExtMessageId { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReadAt { get; set; }
        public ChatMessageDeletedInfo? DeletedInfo { get; set; }
    }
}
