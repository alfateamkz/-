using Alfateam.Core.Attributes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Abstractions.Chats
{
    public class ExternalMessengerChatDTO : ChatDTO
    {
        [ForClientOnly]
        public string Title { get; set; }
        [ForClientOnly]
        public string? ChatPhotoPath { get; set; }
        [ForClientOnly]
        public string ChatId { get; set; }
    }
}
