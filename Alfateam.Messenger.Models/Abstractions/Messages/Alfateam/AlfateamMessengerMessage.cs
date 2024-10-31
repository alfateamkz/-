using Alfateam.Messenger.Models.General.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Messages.Alfateam
{
    public class AlfateamMessengerMessage : Message
    {
        public DateTime? ReadAt { get; set; }
        public ChatMessageDeletedInfo? DeletedInfo { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int AlfateamMessengerChatId { get; set; }
    }
}
