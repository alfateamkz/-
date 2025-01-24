using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Filters;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Administration.Models.DTO.StaticTextsConstructor;
using Alfateam.AdminPanelGeneral.API.Models.Filters.StaticTextsConstructor;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.Administration.Models.StaticTextsConstructor;

namespace Alfateam.AdminPanelGeneral.API.Controllers
{
    [StaticTextsConstructorAccessFilter]
    public class StaticTextsConstructorController : AbsController
    {
        public string ProductIdentifier => Request.Headers["ProductIdentifier"];
        public StaticTextsConstructorController(ControllerParams @params) : base(@params)
        {
            DBService.SetDB(AdmininstrationDb);
        }

        #region Категории текстов

        [HttpGet, Route("GetCategories")]
        public async Task<ItemsWithTotalCount<TextCategoryDTO>> GetCategories(TextCategoriesSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<TextCategory, TextCategoryDTO>(GetAvailableCategories(filter.ParentCategoryId), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCategory")]
        public async Task<TextCategoryDTO> GetCategory(int id)
        {
            return (TextCategoryDTO)DBService.TryGetOne(GetAvailableCategories(), id, new TextCategoryDTO());
        }






        [HttpPost, Route("CreateCategory")]
        public async Task<TextCategoryDTO> CreateCategory(TextCategoryDTO model)
        {
            return (TextCategoryDTO)DBService.TryCreateEntity(AdmininstrationDb.TextCategories, model, callback: (entity) =>
            {
                entity.ProductIdentifier = this.ProductIdentifier;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление категории текстов локализаций", $"Добавлена категория текстов локализаций {entity.Title} для {this.ProductIdentifier}");
            });
        }


        [HttpPut, Route("UpdateCategory")]
        public async Task<TextCategoryDTO> UpdateCategory(TextCategoryDTO model)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (TextCategoryDTO)DBService.TryUpdateEntity(AdmininstrationDb.TextCategories, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование категории текстов локализаций", $"Отредактирована категории текстов локализаций с id={item.Id} для {this.ProductIdentifier}");
            });
        }


        [HttpDelete, Route("DeleteCategory")]
        public async Task DeleteCategory(int id)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.TextCategories, item);

            this.AddHistoryAction("Удаление категории текстов локализаций", $"Удален категория текстов локализаций {item.Title} с id={id} для {this.ProductIdentifier}");
        }

        #endregion

        #region Текста локализаций

        [HttpGet, Route("GetTexts")]
        public async Task<ItemsWithTotalCount<StaticTextsModelDTO>> GetTexts(StaticTextsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<StaticTextsModel, StaticTextsModelDTO>(GetAvailableTexts(filter.CategoryId), filter.Offset, filter.Count, (entity) =>
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
        public async Task<StaticTextsModelDTO> GetText(int id)
        {
            return (StaticTextsModelDTO)DBService.TryGetOne(GetAvailableTexts(), id, new StaticTextsModelDTO());
        }


        [HttpPost, Route("CreateText")]
        public async Task<StaticTextsModelDTO> CreateText(StaticTextsModelDTO model)
        {
            return (StaticTextsModelDTO)DBService.TryCreateEntity(AdmininstrationDb.StaticTextsModels, model,
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление текстов локализаций", $"Добавлен текст локализаций {entity.Title} - {entity.LangCode} для {this.ProductIdentifier}");
            });
        }


        [HttpPut, Route("UpdateText")]
        public async Task<StaticTextsModelDTO> UpdateText(StaticTextsModelDTO model)
        {
            var item = GetAvailableTexts().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            item.Fields.Clear();

            return (StaticTextsModelDTO)DBService.TryUpdateEntity(AdmininstrationDb.StaticTextsModels, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование категории текстов локализаций", $"Отредактирована категории текстов локализаций с id={item.Id} для {this.ProductIdentifier}");
            });
        }

        [HttpDelete, Route("DeleteText")]
        public async Task DeleteText(int id)
        {
            var item = GetAvailableTexts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.StaticTextsModels, item);

            this.AddHistoryAction("Удаление текстов локализаций", $"Удален текст локализаций {item.Title} - {item.LangCode} с id={id} для {this.ProductIdentifier}");
        }

        #endregion








        #region Private methods

        private IEnumerable<TextCategory> GetAvailableCategories()
        {
            return AdmininstrationDb.TextCategories.Where(o => !o.IsDeleted
                                                            && o.ProductIdentifier == this.ProductIdentifier);
        }
        private IEnumerable<TextCategory> GetAvailableCategories(int? parentCategoryId)
        {
            return GetAvailableCategories().Where(o => o.ParentCategoryId == parentCategoryId);
        }

        private IEnumerable<StaticTextsModel> GetAvailableTexts(int categoryId)
        {
            return GetAvailableTexts().Where(o => o.CategoryId == categoryId);
        }

        private IEnumerable<StaticTextsModel> GetAvailableTexts()
        {
            return AdmininstrationDb.StaticTextsModels.Include(o => o.Category)
                                                      .Include(o => o.Fields)
                                                      .Where(o => !o.IsDeleted
                                                               && o.Category.ProductIdentifier == this.ProductIdentifier);
        }

        #endregion
    }
}
