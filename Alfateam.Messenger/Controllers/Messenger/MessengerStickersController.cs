using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using Alfateam.Messenger.Models.StickerSets;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static TdLib.TdApi;

namespace Alfateam.Messenger.API.Controllers.Messenger
{
    public class MessengerStickersController : AbsMessengerController
    {
        public MessengerStickersController(ControllerParams @params) : base(@params)
        {
        }


        #region Сеты стикеров

        [HttpGet, Route("GetStickersSets")]
        public async Task<IEnumerable<AbsStickerSetDTO>> GetStickersSets(int offset = 0, int count = 20)
        {
            IEnumerable<AbsStickerSet> sets = null;
            if(this.Account != null)
            {
                sets = await Messenger.Stickers.GetStickersSets(offset, count);
            }
            else
            {
                sets = DB.StickersSets.Where(o => !o.IsDeleted).Cast<AlfateamStickersSet>();
            }    

            return new AbsStickerSetDTO().CreateDTOs(sets).Cast<AbsStickerSetDTO>();
        }

        [HttpGet, Route("GetStickersSet")]
        public async Task<AbsStickerSetDTO> GetStickersSet(string setId)
        {
            AbsStickerSet set = null;
            if (this.Account != null)
            {
                set = await Messenger.Stickers.GetStickersSet(setId);
            }
            else
            {
                set = DB.StickersSets.FirstOrDefault(o => !o.IsDeleted && o.Id == Convert.ToInt32(setId) && o is AlfateamStickersSet);
            }

            ThrowIfNull(set);
            return (AbsStickerSetDTO)new AbsStickerSetDTO().CreateDTO(set);
        }

        #endregion

        #region Стикеры

        [HttpGet, Route("GetStickersBySet")]
        public async Task<IEnumerable<AbsStickerDTO>> GetStickersBySet(string setId, int offset = 0, int count = 20)
        {
            IEnumerable<AbsSticker> stickers = null;
            if (this.Account != null)
            {
                stickers = await Messenger.Stickers.GetStickersBySet(setId, offset, count);
            }
            else
            {
                stickers = DB.Stickers.Cast<AlfateamSticker>().Where(o => o.StickersSetId == Convert.ToInt32(setId));
            }
             
            return new AbsStickerDTO().CreateDTOs(stickers).Cast<AbsStickerDTO>();
        }

        [HttpGet, Route("GetStickers")]
        public async Task<IEnumerable<AbsStickerDTO>> GetStickers(string query = null, int offset = 0, int count = 20)
        {
            IEnumerable<AbsSticker> stickers = null;
            if (this.Account != null)
            {
                stickers = await Messenger.Stickers.GetStickers(query, offset, count);
            }
            else
            {
                stickers = DB.Stickers.Cast<AlfateamSticker>()
                                      .AsEnumerable()
                                      .Where(o => o.CorrespondingEmoji.Contains(query, StringComparison.OrdinalIgnoreCase)
                                               || o.Title?.Contains(query, StringComparison.OrdinalIgnoreCase) == true);
            }
            return new AbsStickerDTO().CreateDTOs(stickers).Cast<AbsStickerDTO>();
        }

        [HttpGet, Route("GetSticker")]
        public async Task<AbsStickerDTO> GetSticker(string stickerId)
        {
            AbsSticker sticker = null;
            if (this.Account != null)
            {
                sticker = await Messenger.Stickers.GetSticker(stickerId);
            }
            else
            {
                sticker = DB.Stickers.FirstOrDefault(o => o.Id == Convert.ToInt32(sticker));
            }

            ThrowIfNull(sticker);
            return (AbsStickerDTO)new AbsStickerDTO().CreateDTO(sticker);
        }

        #endregion

    }
}
