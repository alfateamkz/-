using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using Alfateam.Messenger.Models.Stickers.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.StickerSets
{
    public class ExternalStickersSet : AbsStickerSet
    {
        public string Title { get; set; }
        public List<ExternalSticker> Stickers { get; set; } = new List<ExternalSticker>();
    }
}
