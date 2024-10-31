using Alfateam.Messenger.Models.Abstractions.Messages.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Messages.External
{
    public class ExternalMessengerUserMessageDTO : ExternalMessengerMessageDTO
    {
        public string SentById { get; set; }
        public List<ExternalMessengerMessageDTO> Forwarded { get; set; } = new List<ExternalMessengerMessageDTO>();
    }
}
