using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels;
using Alfateam2._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Website.API.Controllers.Website
{
    public class MassMediaPostsController : AbsController
    {
        public MassMediaPostsController(WebsiteDBContext db) : base(db)
        {
        }


        [HttpGet, Route("GetPosts")]
        public async Task<IEnumerable<MassMediaPostClientModel>> GetPosts(int offset, int count = 20)
        {
            var items = DB.MassMediaPosts.Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId))
                                         .Skip(offset)
                                         .Take(count)
                                         .ToList();
            return MassMediaPostClientModel.CreateItems(items, LanguageId);
        }

        [HttpPut, Route("AddClick")]
        public async Task<bool> AddClick(int id)
        {
            var post = DB.MassMediaPosts.FirstOrDefault(x => x.Id == id);
            if(post != null)
            {
                post.ClicksCount++;

                DB.MassMediaPosts.Update(post);
                DB.SaveChanges();

                return true;
            }
            return false;
        }
    }
}
