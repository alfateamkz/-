using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Chats
{
    public class PrivateChatDTO : ChatBaseDTO
    {
        [ForClientOnly]
        public PeerDTO CreatedBy { get; set; }



        [DTOFieldFor(DTOFieldForType.CreationOnly)]
        public PeerDTO Receiver { get; set; }
    }
}
