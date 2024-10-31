using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions.Chats;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Messenger.API.Controllers.Messenger
{
    public class MessengerStickersController : AbsMessengerController
    {
        public MessengerStickersController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetStickersSets")]
        public async Task<IEnumerable<AbsStickerSetDTO>> GetStickersSets(int offset = 0, int count = 20)
        {
            var sets = await Messenger.Stickers.GetStickersSets(offset, count);
            return new AbsStickerSetDTO().CreateDTOs(sets).Cast<AbsStickerSetDTO>();
        }

        [HttpGet, Route("GetStickersSet")]
        public async Task<AbsStickerSetDTO> GetStickersSet(string setId)
        {
            var set = await Messenger.Stickers.GetStickersSet(setId);
            return (AbsStickerSetDTO)new AbsStickerSetDTO().CreateDTO(set);
        }




        [HttpGet, Route("GetStickersBySet")]
        public async Task<IEnumerable<AbsStickerDTO>> GetStickersBySet(string setId, int offset = 0, int count = 20)
        {
            var stickers = await Messenger.Stickers.GetStickersBySet(setId, offset, count);
            return new AbsStickerDTO().CreateDTOs(stickers).Cast<AbsStickerDTO>();
        }

        [HttpGet, Route("GetStickers")]
        public async Task<IEnumerable<AbsStickerDTO>> GetStickers(string query = null, int offset = 0, int count = 20)
        {
            var stickers = await Messenger.Stickers.GetStickers(query, offset, count);
            return new AbsStickerDTO().CreateDTOs(stickers).Cast<AbsStickerDTO>();
        }

        [HttpGet, Route("GetSticker")]
        public async Task<AbsStickerDTO> GetSticker(string stickerId)
        {
            var sticker = await Messenger.Stickers.GetSticker(stickerId);
            return (AbsStickerDTO)new AbsStickerDTO().CreateDTO(sticker);
        }
    }
}
