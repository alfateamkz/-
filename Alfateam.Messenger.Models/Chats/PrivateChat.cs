using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Chats
{
    public class PrivateChat : ChatBase
    {
        public Peer CreatedBy { get; set; }
        public int CreatedById { get; set; }


        public Peer Receiver { get; set; }
        public int ReceiverId { get; set; }
    }
}
