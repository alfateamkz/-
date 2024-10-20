using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Chats
{
    public class PrivateChat : Chat
    {
        public string PeerId { get; set; }
        public string OurUserId { get; set; }
    }
}
