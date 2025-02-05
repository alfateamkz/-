using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Models.Filters.Products.Messenger;
using Alfateam.Core;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Stickers.Alfateam;
using Alfateam.Messenger.Models.DTO.StickerSets;
using Alfateam.Messenger.Models.Stickers.Alfateam;
using Alfateam.Messenger.Models.StickerSets;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.Messenger
{
    [Route("Products/Messenger/[controller]")]
    public class MessengerStickersController : AbsController
    {
        public MessengerStickersController(ControllerParams @params) : base(@params)
        {
        }

        #region Сеты стикеров

        [HttpGet, Route("GetStickers")]
        public async Task<ItemsWithTotalCount<AlfateamStickerDTO>> GetStickers([FromQuery] AlfateamStickersSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<AbsSticker, AlfateamStickerDTO>(GetAvailableStickers(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query) && entity is AlfateamSticker alfateamSticker)
                {
                    condition &= alfateamSticker.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                    condition &= alfateamSticker.AlfateamStickersSetId == filter.SetId;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetSticker")]
        public async Task<AlfateamStickerDTO> GetSticker(int id)
        {
            return (AlfateamStickerDTO)DBService.TryGetOne(GetAvailableStickers(), id, new AlfateamStickerDTO());
        }








        [HttpPost, Route("CreateSticker")]
        public async Task<AlfateamStickerDTO> CreateSticker(AlfateamStickerDTO model)
        {
            return (AlfateamStickerDTO)DBService.TryCreateEntity(MessengerDb.Stickers, model);
        }

        [HttpPut, Route("UpdateSticker")]
        public async Task<AlfateamStickerDTO> UpdateSticker(AlfateamStickerDTO model)
        {
            var group = DBService.TryGetOne(GetAvailableStickers(), model.Id);
            return (AlfateamStickerDTO)DBService.TryUpdateEntity(MessengerDb.Stickers, model, group);
        }

        [HttpDelete, Route("DeleteSticker")]
        public async Task DeleteSticker(int id)
        {
            var group = DBService.TryGetOne(GetAvailableStickers(), id);
            DBService.TryDeleteEntity(MessengerDb.Stickers, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<AlfateamSticker> GetAvailableStickers()
        {
            return MessengerDb.Stickers.Where(o => !o.IsDeleted).Cast<AlfateamSticker>();
        }

        #endregion
    }
}
