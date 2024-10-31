using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Abstractions.Modules
{
    public abstract class StickersModule
    {
        public abstract Task<IEnumerable<AbsStickerSet>> GetStickersSets(int offset, int count);
        public abstract Task<AbsStickerSet> GetStickersSet(string setId);

        public abstract Task<IEnumerable<AbsSticker>> GetStickersBySet(string setId, int offset, int count);
        public abstract Task<IEnumerable<AbsSticker>> GetStickers(string query, int offset, int count);
        public abstract Task<AbsSticker> GetSticker(string stickerId);
    }
}
