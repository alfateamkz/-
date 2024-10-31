using Alfateam.Core;
using Alfateam.Messenger.Models.Chats;
using Alfateam.Messenger.Models.Chats.Alfateam;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Messenger.Models.General.Chats.OfflineAutoTime;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Chats
{
    [JsonConverter(typeof(JsonKnownTypesConverter<Chat>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamMessengerChat), "AlfateamMessengerChat")]
    [JsonKnownType(typeof(ExternalMessengerChat), "ExternalMessengerChat")]

    [JsonKnownType(typeof(AlfateamGroupChat), "AlfateamGroupChat")]
    [JsonKnownType(typeof(AlfateamPrivateChat), "AlfateamPrivateChat")]
    [JsonKnownType(typeof(ExternalGroupChat), "ExternalGroupChat")]
    [JsonKnownType(typeof(ExternalPrivateChat), "ExternalPrivateChat")]
    public class Chat : AbsModel
    {
        public List<ChatPersonalSettings> PersonalSettings { get; set; } = new List<ChatPersonalSettings>();

        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? AccountId { get; set; }
    }
}
