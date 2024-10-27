using Alfateam.Messenger.Models.Abstractions.Chats;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Chats.Alfateam
{
    public class AlfateamPrivateChat : AlfateamMessengerChat
    {
        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }


        public User Receiver { get; set; }
        public int ReceiverId { get; set; }
    }
}
