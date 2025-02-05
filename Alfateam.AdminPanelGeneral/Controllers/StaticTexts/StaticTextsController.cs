using Alfateam.Administration.Models.DTO.StaticTextsConstructor;
using Alfateam.Administration.Models.StaticTextsConstructor;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Models.Filters.StaticTextsConstructor;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.StaticTexts
{
    [Route("StaticTexts/[controller]")]
    public class StaticTextsController : AbsStaticTextsController
    {
        public StaticTextsController(ControllerParams @params) : base(@params)
        {
        }

        #region Текста локализаций

        [HttpGet, Route("GetTexts")]
        public async Task<ItemsWithTotalCount<StaticTextsModelDTO>> GetTexts(StaticTextsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<StaticTextsModel, StaticTextsModelDTO>(GetAvailableTexts(filter.ParentTextId), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase)
                        || entity.ClassName.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetText")]
        public async Task<StaticTextsModelDTO> GetText(int textId, int? parentTextId = null)
        {
            return (StaticTextsModelDTO)DBService.TryGetOne(GetAvailableTexts(parentTextId), textId, new StaticTextsModelDTO());
        }


        [HttpPost, Route("CreateText")]
        public async Task<StaticTextsModelDTO> CreateText(StaticTextsModelDTO model)
        {
            return (StaticTextsModelDTO)DBService.TryCreateEntity(AdmininstrationDb.StaticTextsModels, model, callback: (entity) =>
            {
                entity.TextsSetLanguageZoneId = this.TextsSetLanguageZoneId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление текстов локализаций", $"Добавлен текст локализаций {entity.Title}");
            });
        }


        [HttpPut, Route("UpdateText")]
        public async Task<StaticTextsModelDTO> UpdateText(StaticTextsModelDTO model, int? parentTextId = null)
        {
            var item = GetAvailableTexts(parentTextId).FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            item.Fields.Clear();

            return (StaticTextsModelDTO)DBService.TryUpdateEntity(AdmininstrationDb.StaticTextsModels, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование категории текстов локализаций", $"Отредактирована категории текстов локализаций с id={item.Id}");
            });
        }

        [HttpDelete, Route("DeleteText")]
        public async Task DeleteText(int id, int? parentTextId = null)
        {
            var item = GetAvailableTexts(parentTextId).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.StaticTextsModels, item);

            this.AddHistoryAction("Удаление текстов локализаций", $"Удален текст локализаций {item.Title} с id={id}");
        }

        #endregion








        #region Private methods

        private IEnumerable<StaticTextsModel> GetAvailableTexts(int? parentTextId)
        {
            return AdmininstrationDb.StaticTextsModels.Include(o => o.SubTexts)
                                                      .Include(o => o.Fields)
                                                      .Where(o => !o.IsDeleted 
                                                                && o.TextsSetLanguageZoneId == this.TextsSetLanguageZoneId 
                                                                && o.StaticTextsModelId == parentTextId);
        }

        private IEnumerable<StaticTextsModel> GetAvailableRootTexts()
        {
            return AdmininstrationDb.StaticTextsModels.Include(o => o.SubTexts)
                                                      .Include(o => o.Fields)
                                                      .Where(o => !o.IsDeleted 
                                                                && o.TextsSetLanguageZoneId == this.TextsSetLanguageZoneId
                                                                && o.StaticTextsModelId == null);
        }

        #endregion
    }
}
