using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam.Website.API.Models.Core;
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
        public PostsController(WebsiteDBContext db) : base(db)
        {
        }

        [HttpGet, Route("GetPosts")]
        public async Task<IEnumerable<PostClientModel>> GetPosts(int offset, int count = 20)
        {
            var items = GetPosts().Skip(offset).Take(count).ToList();

            return PostClientModel.CreateItems(items,LanguageId);
        }

        [HttpGet, Route("GetPostsByFilter")]
        public async Task<IEnumerable<PostClientModel>> GetPostsByFilter(PostsSearchFilter filter)
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

            return PostClientModel.CreateItems(posts.ToList(), LanguageId);
        }


        [HttpGet, Route("GetPost")]
        public async Task<PostClientModel> GetPost(int id)
        {
            var post = GetFullIncludedPosts().FirstOrDefault(o => o.Id == id);
            return PostClientModel.Create(post, LanguageId);
        }





        [HttpPut, Route("AddWatch")]
        public async Task<RequestResult> AddWatch(int id, string fingerprint)
        {
            var res = new RequestResult();

            var post = DB.Posts.FirstOrDefault(o => o.Id == id);
            if (post != null)
            {

                int? userId = null;
                if (!string.IsNullOrEmpty(this.UserSessid))
                {
                    var session = DB.Sessions.Include(o => o.User)
                                             .FirstOrDefault(o => o.SessID == this.UserSessid);

                    var checkSessionRes = CheckSession(session);
                    if (!checkSessionRes.Success)
                    {
                        res.FillFromRequestResult(checkSessionRes);
                        return res;
                    }
                    userId = session.User.Id;
                }


                post.Watches++;
                post.WatchesList.Add(new Watch
                {
                    WatchedByFingerprint = fingerprint,
                    WatchedById = userId,
                });

                DB.Posts.Update(post);
                DB.SaveChanges();
            }
            else
            {
                res.Code = 404;
                res.Error = "Новость по данному id не найдена";
            }

            return res;
        }






        [HttpGet, Route("GetPostCategories")]
        public async Task<IEnumerable<PostCategoryClientModel>> GetPostCategories()
        {
            var items = DB.PostCategories.IncludeAvailability()
                                         .Include(o => o.Localizations)
                                         .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                         .ToList();
            return PostCategoryClientModel.CreateItems(items,LanguageId);
        }
        [HttpGet, Route("GetPostIndustries")]
        public async Task<IEnumerable<PostIndustryClientModel>> GetPostIndustries()
        {
            var items = DB.PostIndustries.IncludeAvailability()
                                         .Include(o => o.Localizations)
                                         .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                         .ToList();
            return PostIndustryClientModel.CreateItems(items, LanguageId);
        }


        #region Private methods
        public IQueryable<Post> GetPosts()
        {
            return DB.Posts.IncludeAvailability()
                            .Include(o => o.Category).ThenInclude(o => o.Localizations)
                            .Include(o => o.Industry).ThenInclude(o => o.Localizations)
                            .Include(o => o.Content).ThenInclude(o => o.Items)
                            .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                            .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }
        public IQueryable<Post> GetFullIncludedPosts()
        {
            return DB.Posts.IncludeAvailability()
                            .Include(o => o.Category).ThenInclude(o => o.Localizations)
                            .Include(o => o.Industry).ThenInclude(o => o.Localizations)
                            .Include(o => o.Content).ThenInclude(o => o.Items)
                            .Include(o => o.WatchesList).ThenInclude(o => o.WatchedBy)
                            .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                            .Include(o => o.MainLanguage)
                            .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }

        #endregion
    }
}
