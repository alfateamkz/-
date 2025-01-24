using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.Blogs.Feedbacks.Reactions;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Filters;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Reactions;
using Alfateam.AdminPanelGeneral.API.Models.Filters.Blogs;
using Alfateam.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Blogs
{
    [BlogsAccessFilter]
    public class BlogPostsController : AbsBlogController
    {
        public BlogPostsController(ControllerParams @params) : base(@params)
        {
        }


        #region Посты

        [HttpGet, Route("GetPosts")]
        public async Task<ItemsWithTotalCount<BlogPostDTO>> GetPosts(BlogPostsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BlogPost, BlogPostDTO>(GetAvailablePosts(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition  &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if(filter.CategoryId != null)
                {
                    condition &= entity.Categories.Any(o => o.Id == filter.CategoryId);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetPost")]
        public async Task<BlogPostDTO> GetPost(int id)
        {
            return (BlogPostDTO)DBService.TryGetOne(GetAvailablePosts(), id, new BlogPostDTO());
        }

        //TODO: create and update post


        [HttpDelete, Route("DeletePost")]
        public async Task DeletePost(int id)
        {
            var item = GetAvailablePosts().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(AdmininstrationDb.BlogPosts, item);

            this.AddHistoryAction("Удаление поста для блога", $"Удалена поста для блога {item.Title} с id={id}");
        }

        #endregion



        #region Private methods
        private IEnumerable<BlogPost> GetAvailablePosts()
        {
            return AdmininstrationDb.BlogPosts.Include(o => o.Categories)
                                              .Include(o => o.Blocks)
                                              .Include(o => o.ReactionCounters).ThenInclude(o => o.Reaction)
                                              .Include(o => o.WatchesCounter)
                                              .Include(o => o.CommentsCounter)
                                              .Where(o => !o.IsDeleted && o.BlogId == this.BlogId);
        }

        #endregion
    }
}
