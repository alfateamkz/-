using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.Chats
{ 
    public class ChatPersonalSettingsDTO : DTOModelAbs<ChatPersonalSettings>
    {

        [ForClientOnly]
        public ChatFolderDTO? Folder { get; set; }


        [ForClientOnly]
        [Description("Порядок закрепления чата в списке чатов\r\n Если PinnedOrder -1, то чат не закреплен ")]
        public int PinnedOrder { get; set; } = -1;

        [ForClientOnly]
        public ChatNotificationSettingsDTO Notifications { get; set; }
    }
}
