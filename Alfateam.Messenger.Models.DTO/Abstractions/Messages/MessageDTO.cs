using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Messages
{
    public class MessageDTO : DTOModelAbs<Message>
    {
        public DateTime? ReadAt { get; set; }
    }
}
