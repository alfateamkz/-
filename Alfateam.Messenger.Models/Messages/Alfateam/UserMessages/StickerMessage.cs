using Alfateam.Messenger.Models.Abstractions.Messages.Alfateam;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.Alfateam.UserMessages
{
    public class StickerMessage : AlfateamMessengerUserMessage
    {
        public AlfateamSticker Sticker { get; set; }
        public int StickerId { get; set; }
    }
}
