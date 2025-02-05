using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Alfateam.Marketing.API.Models.DTO.General.SEO.UserAgents;
using Alfateam.Marketing.Models.General.SEO.UserAgents;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Alfateam.Messenger.Models.DTO.StickerSets;
using Alfateam.Messenger.Models.StickerSets;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Products.Messenger
{
    [Route("Products/Messenger/[controller]")]
    public class MessengerStickersSetsController : AbsController
    {
        public MessengerStickersSetsController(ControllerParams @params) : base(@params)
        {
        }

        #region Сеты стикеров

        [HttpGet, Route("GetStickersSets")]
        public async Task<ItemsWithTotalCount<AlfateamStickersSetDTO>> GetStickersSets([FromQuery] SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<AbsStickerSet, AlfateamStickersSetDTO>(GetAvailableStickersSets(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query) && entity is AlfateamStickersSet alfateamStickersSet)
                {
                    condition &= alfateamStickersSet.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetStickersSet")]
        public async Task<AlfateamStickersSetDTO> GetStickersSet(int id)
        {
            return (AlfateamStickersSetDTO)DBService.TryGetOne(GetAvailableStickersSets(), id, new AlfateamStickersSetDTO());
        }








        [HttpPost, Route("CreateStickersSet")]
        public async Task<AlfateamStickersSetDTO> CreateStickersSet(AlfateamStickersSetDTO model)
        {
            return (AlfateamStickersSetDTO)DBService.TryCreateEntity(MessengerDb.StickersSets, model);
        }

        [HttpPut, Route("UpdateStickersSet")]
        public async Task<AlfateamStickersSetDTO> UpdateStickersSet(AlfateamStickersSetDTO model)
        {
            var group = DBService.TryGetOne(GetAvailableStickersSets(), model.Id);
            return (AlfateamStickersSetDTO)DBService.TryUpdateEntity(MessengerDb.StickersSets, model, group);
        }

        [HttpDelete, Route("DeleteStickersSet")]
        public async Task DeleteStickersSet(int id)
        {
            var group = DBService.TryGetOne(GetAvailableStickersSets(), id);
            DBService.TryDeleteEntity(MessengerDb.StickersSets, group);
        }

        #endregion









        #region Private methods
        private IEnumerable<AlfateamStickersSet> GetAvailableStickersSets()
        {
            return MessengerDb.StickersSets.Where(o => !o.IsDeleted).Cast<AlfateamStickersSet>();
        }

        #endregion
    }
}
