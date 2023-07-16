using Alfateam.CRM2_0.Models.Abstractions.Communication.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Communication.Messenger.Messages
{
    /// <summary>
    /// Модель обычного сообщения в чате
    /// </summary>
    public class CommonMessage : Message
    {
        public string Message { get; set; }
        public List<ChatMessageAttachment> Attachments { get; set; } = new List<ChatMessageAttachment>();
    }
}
