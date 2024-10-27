using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using Alfateam.Messenger.Models.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.SystemMessages
{
    public class KickedUserMessageDTO : SystemMessageDTO
    {
        [ForClientOnly]
        public UserDTO KickedUser { get; set; }
        [ForClientOnly]
        public UserDTO KickedBy { get; set; }
    }
}
