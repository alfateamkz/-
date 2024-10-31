using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Messages.External
{
    public class ExternalMessengerMessageDTO : MessageDTO
    {
        public string MessageId { get; set; }
        public DateTime SentAt { get; set; }




        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
    }
}
