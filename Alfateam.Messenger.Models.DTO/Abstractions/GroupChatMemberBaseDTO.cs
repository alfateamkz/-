using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.General.GroupChats.Members;
using Alfateam.Messenger.Models.General.GroupChats.Members;
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
    [JsonConverter(typeof(JsonKnownTypesConverter<GroupChatMemberBaseDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(AlfateamGroupChatMemberDTO), "AlfateamGroupChatMember")]
    [JsonKnownType(typeof(ExtGroupChatMemberDTO), "ExtGroupChatMember")]
    public class GroupChatMemberBaseDTO : DTOModelAbs<GroupChatMemberBase>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }
    }
}
