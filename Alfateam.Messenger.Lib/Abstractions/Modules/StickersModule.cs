using Alfateam.Messenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Abstractions.Modules
{
    public abstract class StickersModule
    {
        public abstract Task<IEnumerable<Sticker>> GetStickers(string query, int offset, int count);
        public abstract Task<Sticker> GetSticker(string stickerId);
    }
}
