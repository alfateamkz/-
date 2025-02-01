using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.General.GroupChats.Members;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<GroupChatMemberBase>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamGroupChatMember), "AlfateamGroupChatMember")]
    [JsonKnownType(typeof(ExtGroupChatMember), "ExtGroupChatMember")]
    public class GroupChatMemberBase : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int GroupChatId { get; set; }
    }
}
