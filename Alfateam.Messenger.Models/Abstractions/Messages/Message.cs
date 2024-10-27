using Alfateam.Core;
using Alfateam.Messenger.Models.General;
using Alfateam.Messenger.Models.General.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Messages
{
    public class Message : AbsModel
    {
     



        public DateTime? ReadAt { get; set; }
        public ChatMessageDeletedInfo? DeletedInfo { get; set; }
    }
}
