using Alfateam.Administration.Models.Blogs;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.AdminPanelGeneral.API.Models.Filters.Blogs;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Blogs
{
    public class BlogsController : AbsBlogController
    {
        public BlogsController(ControllerParams @params) : base(@params)
        {
        }

        #region Блоги, wiki и фак ю (FAQ)

        [HttpGet, Route("GetBlogs")]
        public async Task<ItemsWithTotalCount<BlogDTO>> GetBlogs(BlogsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Blog, BlogDTO>(GetAvailableBlogs(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if(filter.BlogType != null)
                {
                    condition &= entity.Type == filter.BlogType;
                }

                return condition;
            });
        }

        [HttpGet, Route("GetBlog")]
        public async Task<BlogDTO> GetBlog(int id)
        {
            return (BlogDTO)DBService.TryGetOne(GetAvailableBlogs(), id, new BlogDTO());
        }



        [HttpPost, Route("CreateBlog")]
        public async Task<BlogDTO> CreateBlog(BlogDTO model)
        {
            return (BlogDTO)DBService.TryCreateEntity(AdmininstrationDb.Blogs, model,afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление блога", $"Добавлен блога {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateBlog")]
        public async Task<BlogDTO> UpdateBlog(BlogDTO model)
        {
            var item = GetAvailableBlogs().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (BlogDTO)DBService.TryUpdateEntity(AdmininstrationDb.Blogs, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование блога", $"Отредактирован блог с id={item.Id}");
            });
        }

        [HttpDelete, Route("DeleteBlog")]
        public async Task DeleteBlog(int id)
        {
            var item = GetAvailableBlogs().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.Blogs, item);

            this.AddHistoryAction("Удаление блога", $"Удален блог {item.Title} с id={id}");
        }
        #endregion





        #region Private methods
        private IEnumerable<Blog> GetAvailableBlogs()
        {
            return AdmininstrationDb.Blogs.Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
