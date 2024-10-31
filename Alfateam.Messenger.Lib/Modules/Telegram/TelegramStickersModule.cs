using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using Alfateam.Messenger.Models.Stickers.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdLib;

namespace Alfateam.Messenger.Lib.Modules.Telegram
{
    public class TelegramStickersModule : StickersModule
    {
        private TelegramMessenger Messenger;
        public TelegramStickersModule(TelegramMessenger messenger)
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
            var stickers = await GetStickers(null, 0, int.MaxValue);
            return stickers.FirstOrDefault(o => o.Id == Convert.ToInt32(stickerId));
        }
        public override async Task<IEnumerable<AbsSticker>> GetStickers(string query, int offset, int count)
        {
            var stickersResponse = await Messenger.Client.GetStickersAsync(query: query, limit: int.MaxValue);
            var tgStickers = stickersResponse.Stickers_.Skip(offset).Take(count).ToArray();


            var universalStickers = new List<ExternalSticker>();
            foreach (var tgSticker in tgStickers)
            {
                universalStickers.Add(TransformTgStickerToUniversal(tgSticker));
            }

            return universalStickers;
        }





        private ExternalSticker TransformTgStickerToUniversal(TdApi.Sticker sticker)
        {
            var universal = new ExternalSticker()
            {
                CorrespondingEmoji = sticker.Emoji,
                StickerId = sticker.Id.ToString(),
                Filepath = sticker.Sticker_.Remote.UniqueId
            };

            return universal;
        }
    }
}
