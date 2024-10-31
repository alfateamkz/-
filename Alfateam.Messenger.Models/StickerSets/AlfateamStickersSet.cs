using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.StickerSets
{
    public class AlfateamStickersSet : AbsStickerSet
    {
        public string Title { get; set; }
        public List<AlfateamSticker> Stickers { get; set; } = new List<AlfateamSticker>();
    }
}
