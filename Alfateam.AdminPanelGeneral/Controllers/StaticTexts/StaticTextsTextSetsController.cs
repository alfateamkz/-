using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;
using Alfateam.Administration.Models.StaticTextsConstructor;
using Alfateam.Administration.Models.DTO.StaticTextsConstructor;
using Alfateam.AdminPanelGeneral.API.Models.Filters.StaticTextsConstructor;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.StaticTexts
{
    [Route("StaticTexts/[controller]")]
    public class StaticTextsTextSetsController : AbsStaticTextsController
    {
        public StaticTextsTextSetsController(ControllerParams @params) : base(@params)
        {
        }

        #region Наборы статических текстов

        [HttpGet, Route("GetTextSets")]
        public async Task<ItemsWithTotalCount<TextsSetDTO>> GetTextSets(StaticTextsTexSetsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<TextsSet, TextsSetDTO>(GetAvailableTextsSets(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.ProductId != null)
                {
                    condition &= entity.ProductId == filter.ProductId;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetTextsSet")]
        public async Task<TextsSetDTO> GetTextsSet(int id)
        {
            return (TextsSetDTO)DBService.TryGetOne(GetAvailableTextsSets(), id, new TextsSetDTO());
        }



        [HttpPost, Route("CreateTextsSet")]
        public async Task<TextsSetDTO> CreateTextsSet(TextsSetDTO model)
        {
            return (TextsSetDTO)DBService.TryCreateEntity(AdmininstrationDb.TextsSets, model, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление набора статических текстов", $"Добавлен набор статических текстов {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateTextsSet")]
        public async Task<TextsSetDTO> UpdateTextsSet(TextsSetDTO model)
        {
            var item = GetAvailableTextsSets().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (TextsSetDTO)DBService.TryUpdateEntity(AdmininstrationDb.TextsSets, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование набора статических текстов", $"Отредактирован набор статических текстов с id={item.Id}");
            });
        }

        [HttpDelete, Route("DeleteTextsSet")]
        public async Task DeleteTextsSet(int id)
        {
            var item = GetAvailableTextsSets().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.TextsSets, item);

            this.AddHistoryAction("Удаление набора статических текстов", $"Удален набор статических текстов {item.Title} с id={id}");
        }

        #endregion









        #region Private methods
        private IEnumerable<TextsSet> GetAvailableTextsSets()
        {
            return AdmininstrationDb.TextsSets.Include(o => o.Product)
                                              .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
