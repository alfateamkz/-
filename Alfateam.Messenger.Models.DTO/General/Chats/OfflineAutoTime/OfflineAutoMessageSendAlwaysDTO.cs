using Alfateam.Messenger.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General.Chats.OfflineAutoTime
{
    public class OfflineAutoMessageSendAlwaysDTO : OfflineAutoMessageSendTimeDTO
    {
        public bool NeedToSend { get; set; }
    }
}
