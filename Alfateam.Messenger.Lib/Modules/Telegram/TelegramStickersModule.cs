using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models;
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


        public override async Task<Sticker> GetSticker(string stickerId)
        {
            var stickers = await GetStickers(null, 0, int.MaxValue);
            return stickers.FirstOrDefault(o => o.Id == Convert.ToInt32(stickerId));
        }
        public override async Task<IEnumerable<Sticker>> GetStickers(string query, int offset, int count)
        {
            var stickersResponse = await Messenger.Client.GetStickersAsync(query: query, limit: int.MaxValue);
            var tgStickers = stickersResponse.Stickers_.Skip(offset).Take(count).ToArray();


            var universalStickers = new List<Sticker>();
            foreach (var tgSticker in tgStickers)
            {
                universalStickers.Add(TransformTgStickerToUniversal(tgSticker));
            }

            return universalStickers;
        }





        private Sticker TransformTgStickerToUniversal(TdApi.Sticker sticker)
        {
            var universal = new Sticker()
            {
                CorrespondingEmoji = sticker.Emoji,
                StickerId = sticker.Id.ToString(),
                Filepath = sticker.Sticker_.Remote.UniqueId
            };

            return universal;
        }
    }
}
