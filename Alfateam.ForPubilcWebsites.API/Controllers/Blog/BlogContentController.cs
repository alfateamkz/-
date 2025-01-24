using Alfateam.Administration.Models.Blogs;
using Alfateam.Administration.Models.DTO.Blogs;
using Alfateam.Administration.Models.DTO.Blogs.Feedbacks.Watches;
using Alfateam.Core;
using Alfateam.Core.Exceptions;
using Alfateam.ForPubilcWebsites.API.Abstractions;
using Alfateam.ForPubilcWebsites.API.Models;
using Alfateam.ForPubilcWebsites.API.Models.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.ForPubilcWebsites.API.Controllers.Blog
{
    public class BlogContentController : AbsBlogController
    {
        public BlogContentController(ControllerParams @params) : base(@params)
        {
        }

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

        [HttpGet, Route("GetPosts")]
        public async Task<ItemsWithTotalCount<BlogPostDTO>> GetPosts(BlogPostsSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<BlogPost, BlogPostDTO>(GetAvailablePosts(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.CategoryId != null)
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



        [HttpPut, Route("SetWatch")]
        public async Task SetWatch(int id, WatchDTO model)
        {
            var post = DBService.TryGetOne(GetAvailablePosts(), id);

            if (!model.IsValid())
            {
                throw new Exception400("Проверьте правильность заполнения полей");
            }

            var watch = model.CreateDBModelFromDTO();
            post.WatchesCounter.AddWatch(watch);

            DBService.UpdateEntity(AdmininstrationDb.BlogPosts, post);
        }



        #region Private methods
        private IEnumerable<BlogCategory> GetAvailableCategories()
        {
            return AdmininstrationDb.BlogCategories.Where(o => !o.IsDeleted && o.BlogId == this.BlogId);
        }

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
