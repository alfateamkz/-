using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Abstractions.Messages.External
{
    public class ExternalMessengerMessage : Message
    {
        public string MessageId { get; set; }
        public DateTime SentAt { get; set; }




        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
