using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Chats
{
    public class OfflineAutoMessageSettings : AbsModel
    {
        public bool IsActive { get; set; }
        public string Message { get; set; }


        public OfflineAutoMessageSendTime SendTimeInfo { get; set; }
    }
}
