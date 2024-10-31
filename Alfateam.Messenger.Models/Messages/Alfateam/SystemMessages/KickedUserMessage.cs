using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using Alfateam.Messenger.Models.Accounts;
using Alfateam.Messenger.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.Alfateam.SystemMessages
{
    public class KickedUserMessage : AlfateamMessengerSystemMessage
    {
        public AlfateamMessengerAccount KickedUser { get; set; }
        public int KickedUserId { get; set; }




        public AlfateamMessengerAccount KickedBy { get; set; }
        public int KickedById { get; set; }
    }
}
