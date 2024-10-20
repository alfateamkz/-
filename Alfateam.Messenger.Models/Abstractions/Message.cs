using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions
{
    public class Message : AbsModel
    {
        public string MessageId { get; set; }
        public List<Message> AnsweredMessages { get; set; } = new List<Message>();

        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
