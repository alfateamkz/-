using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Messages.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Messages.Alfateam.UserMessages
{
    public class StickerMessageDTO : AlfateamMessengerUserMessageDTO
    {
        [ForClientOnly]
        public AbsStickerDTO Sticker { get; set; }

        [HiddenFromClient]
        public int StickerId { get; set; }
    }
}
