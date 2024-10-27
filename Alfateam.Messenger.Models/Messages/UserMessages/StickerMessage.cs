using Alfateam.Messenger.Models.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Messages.UserMessages
{
    public class StickerMessage : UserMessage
    {
        public Sticker Sticker { get; set; }
        public int StickerId { get; set; }
    }
}
