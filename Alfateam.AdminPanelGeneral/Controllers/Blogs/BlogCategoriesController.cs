using Alfateam.Administration.Models.Blogs;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Filters;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.Administration.Models.DTO.StaticTextsConstructor;
using Alfateam.AdminPanelGeneral.API.Models.Filters.StaticTextsConstructor;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Blogs
{
    [BlogsAccessFilter]
    [Route("Blogs/[controller]")]
    public class BlogCategoriesController : AbsBlogController
    {
        public BlogCategoriesController(ControllerParams @params) : base(@params)
        {
        }

        #region Категории блога

        [HttpGet, Route("GetCategories")]
        public async Task<ItemsWithTotalCount<BlogCategoryDTO>> GetCategories(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BlogCategory, BlogCategoryDTO>(GetAvailableCategories(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetCategory")]
        public async Task<BlogCategoryDTO> GetCategory(int id)
        {
            return (BlogCategoryDTO)DBService.TryGetOne(GetAvailableCategories(), id, new BlogCategoryDTO());
        }





        [HttpPost, Route("CreateCategory")]
        public async Task<BlogCategoryDTO> CreateCategory(BlogCategoryDTO model)
        {
            return (BlogCategoryDTO)DBService.TryCreateEntity(AdmininstrationDb.BlogCategories, model, callback: (entity) =>
            {
                entity.BlogLanguageZoneId = (int)this.BlogLanguageZoneId;
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление категории блога", $"Добавлена категория блога {entity.Title}");
            });
        }


        [HttpPut, Route("UpdateCategory")]
        public async Task<BlogCategoryDTO> UpdateCategory(BlogCategoryDTO model)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (BlogCategoryDTO)DBService.TryUpdateEntity(AdmininstrationDb.BlogCategories, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование категории блога", $"Отредактирована категории блога с id={item.Id}");
            });
        }


        [HttpDelete, Route("DeleteCategory")]
        public async Task DeleteCategory(int id)
        {
            var item = GetAvailableCategories().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.BlogCategories, item);

            this.AddHistoryAction("Удаление категории блога", $"Удалена категория блога {item.Title} с id={id}");
        }

        #endregion







        #region Private methods
        private IEnumerable<BlogCategory> GetAvailableCategories()
        {
            return AdmininstrationDb.BlogCategories.Where(o => !o.IsDeleted && o.BlogLanguageZoneId == this.BlogLanguageZoneId);
        }

        #endregion
    }
}
