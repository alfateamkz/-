using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.Posts;
using Alfateam.Website.API.Models.Filters;
using Alfateam2._0.Models;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Website
{
    public class PostsController : AbsController
    {
        public PostsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetPosts")]
        public async Task<IEnumerable<PostDTO>> GetPosts(int offset, int count = 20)
        {
            var items = GetPosts().Skip(offset).Take(count).ToList();
            return new PostDTO().CreateDTOsWithLocalization(items,LanguageId).Cast<PostDTO>();
        }

        [HttpGet, Route("GetPostsByFilter")]
        public async Task<IEnumerable<PostDTO>> GetPostsByFilter([FromQuery] ClientPostsSearchFilter filter)
        {
            var posts = GetPosts();

            if (filter.CategoryId > 0)
            {
                posts = posts.Where(o => o.Category.Id == filter.CategoryId);
            }
            if (filter.IndustryId > 0)
            {
                posts = posts.Where(o => o.Industry.Id == filter.IndustryId);
            }
            if (!string.IsNullOrEmpty(filter.Query))
            {
                posts = posts.Where(o => o.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase));
            }
            posts = posts.Skip(filter.Offset).Take(filter.Count);

            return new PostDTO().CreateDTOsWithLocalization(posts.ToList(), LanguageId).Cast<PostDTO>();
        }


        [HttpGet, Route("GetPost")]
        public async Task<PostDTO> GetPost(int id)
        {
            var post = GetFullIncludedPosts().FirstOrDefault(o => o.Id == id);
            return (PostDTO)new PostDTO().CreateDTOWithLocalization(post, LanguageId);
        }





        [HttpPut, Route("AddWatch")]
        public async Task AddWatch(int id, string fingerprint)
        {
            var post = DB.Posts.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (post == null)
            {
                throw new Exception404("Новость по данному id не найдена");
            }

            post.Watches++;
            post.WatchesList.Add(new Watch
            {
                WatchedByFingerprint = fingerprint,
                WatchedById = GetUserIdIfSessionValid(),
            });

            DbService.UpdateEntity(DB.Posts, post);
        }






        [HttpGet, Route("GetPostCategories")]
        public async Task<IEnumerable<PostCategoryDTO>> GetPostCategories()
        {
            var items = DB.PostCategories.IncludeAvailability()
                                         .Include(o => o.Localizations)
                                         .ToList()
                                         .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
            return new PostCategoryDTO().CreateDTOsWithLocalization(items,LanguageId).Cast<PostCategoryDTO>();
        }
        [HttpGet, Route("GetPostIndustries")]
        public async Task<IEnumerable<PostIndustryDTO>> GetPostIndustries()
        {
            var items = DB.PostIndustries.IncludeAvailability()
                                         .Include(o => o.Localizations)
                                         .ToList()
                                         .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
            return new PostIndustryDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<PostIndustryDTO>();
        }


        #region Private methods
        private IEnumerable<Post> GetPosts()
        {
            return DB.Posts.IncludeAvailability()
                            .Include(o => o.Category).ThenInclude(o => o.Localizations)
                            .Include(o => o.Industry).ThenInclude(o => o.Localizations)
                            .Include(o => o.Content).ThenInclude(o => o.Items)
                            .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                            .ToList()
                            .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }
        private IEnumerable<Post> GetFullIncludedPosts()
        {
            return DB.Posts.IncludeAvailability()
                            .Include(o => o.Category).ThenInclude(o => o.Localizations)
                            .Include(o => o.Industry).ThenInclude(o => o.Localizations)
                            .Include(o => o.Content).ThenInclude(o => o.Items)
                            .Include(o => o.WatchesList).ThenInclude(o => o.WatchedBy)
                            .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                            .Include(o => o.MainLanguage)
                            .ToList()
                            .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }

        #endregion
    }
}
