using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.UserMessages
{
    public class StickerMessageDTO : UserMessageDTO
    {
        [ForClientOnly]
        public StickerDTO Sticker { get; set; }

        [HiddenFromClient]
        public int StickerId { get; set; }
    }
}
