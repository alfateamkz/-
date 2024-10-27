using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.SystemMessages
{
    public class KickedUserMessage : SystemMessage
    {
        public User KickedUser { get; set; }
        public int KickedUserId { get; set; }




        public User KickedBy { get; set; }
        public int KickedById { get; set; }
    }
}
