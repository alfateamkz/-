using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General.Chats
{
    public class ChatMessageDeletedInfo : AbsModel
    {
        public Peer PeerBy { get; set; }
        public int DeletedById { get; set; }



        public DateTime MessageDeletedAt { get; set; }
        public bool MessageDeletedForAll { get; set; }
    }
}
