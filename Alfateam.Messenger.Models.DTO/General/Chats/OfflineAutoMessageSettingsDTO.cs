using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.General.Chats;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.Chats
{
    public class OfflineAutoMessageSettingsDTO : DTOModelAbs<OfflineAutoMessageSettings>
    {
        public bool IsActive { get; set; }
        public string Message { get; set; }


        public OfflineAutoMessageSendTimeDTO SendTimeInfo { get; set; }
    }
}
