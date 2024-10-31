using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Facebook
{
    public class FacebookStickersModule : StickersModule
    {
        private FacebookMessenger Messenger;
        public FacebookStickersModule(FacebookMessenger messenger)
        {
            Messenger = messenger;
        }

        public override async Task<IEnumerable<AbsStickerSet>> GetStickersSets(int offset, int count)
        {
            throw new NotImplementedException();
        }
        public override async Task<AbsStickerSet> GetStickersSet(string setId)
        {
            throw new NotImplementedException();
        }




        public override async Task<IEnumerable<AbsSticker>> GetStickersBySet(string setId, int offset, int count)
        {
            throw new NotImplementedException();
        }
        public override async Task<AbsSticker> GetSticker(string stickerId)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<AbsSticker>> GetStickers(string query, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
