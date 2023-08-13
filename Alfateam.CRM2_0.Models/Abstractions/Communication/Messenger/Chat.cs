using Alfateam.CRM2_0.Models.Communication.Messenger.Chats;
using Alfateam.CRM2_0.Models.General.Taxes;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger
{


    [JsonConverter(typeof(JsonKnownTypesConverter<Chat>))]
    [JsonDiscriminator(Name = "Discriminator")]
    [JsonKnownType(typeof(GroupChat), "GroupChat")]
    [JsonKnownType(typeof(PrivateChat), "PrivateChat")]
    /// <summary>
    /// Базовая модель чата
    /// </summary>
    public abstract class Chat : AbsModel
    {
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
