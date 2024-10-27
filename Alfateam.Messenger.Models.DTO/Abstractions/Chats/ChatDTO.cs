using Alfateam.Messenger.Models.Abstractions.Chats;
using Alfateam.Messenger.Models.DTO.General.Chats;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Chats
{
    public class ChatDTO : DTOModelAbs<Chat>
    {
        public ChatPersonalSettingsDTO UserPersonalSettings { get; set; }
    }
}
