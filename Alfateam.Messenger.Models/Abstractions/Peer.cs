using Alfateam.Core;
using Alfateam.Messenger.Models.MessageAttachments;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<Peer>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamExtMessengerPeer), "AlfateamExtMessengerPeer")]
    [JsonKnownType(typeof(AlfateamMessengerPeer), "AlfateamMessengerPeer")]
    [JsonKnownType(typeof(ExtMessengerPeer), "ExtMessengerPeer")]
    public class Peer : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? PrivateChatId { get; set; }

        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int? AlfateamGroupChatMemberId { get; set; }





        public virtual string GetPeerUserId()
        {
            throw new Exception("Абстрактная сущность");
        }
    }
}
