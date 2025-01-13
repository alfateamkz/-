using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Viber
{
    public class ViberStickersModule : StickersModule
    {
        private ViberMessenger Messenger;
        public ViberStickersModule(ViberMessenger messenger)
        {
            Messenger = messenger;
        }



        public override Task<AbsSticker> GetSticker(string stickerId)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<AbsSticker>> GetStickers(string query, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<AbsSticker>> GetStickersBySet(string setId, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override Task<AbsStickerSet> GetStickersSet(string setId)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<AbsStickerSet>> GetStickersSets(int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
