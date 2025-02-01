using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Abstractions.Messages;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.UserMessages
{
    public class StickerMessage : UserMessage
    {
        public AbsSticker Sticker { get; set; }
        public int StickerId { get; set; }
    }
}
