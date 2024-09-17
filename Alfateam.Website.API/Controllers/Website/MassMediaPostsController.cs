using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO;
using Alfateam2._0.Models;
using Alfateam2._0.Models.HR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Website
{
    public class MassMediaPostsController : AbsController
    {
        public MassMediaPostsController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetPosts")]
        public async Task<IEnumerable<MassMediaPostDTO>> GetPosts(int offset, int count = 20)
        {
            var items = GetMassMediaPosts().Skip(offset).Take(count).ToList();
            return new MassMediaPostDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<MassMediaPostDTO>();
        }

        [HttpPut, Route("AddClick")]
        public async Task<bool> AddClick(int id)
        {
            var post = DB.MassMediaPosts.FirstOrDefault(x => x.Id == id);
            if(post != null)
            {
                post.ClicksCount++;
                DbService.UpdateEntity(DB.MassMediaPosts, post);

                return true;
            }
            return false;
        }


        #region Private methods
        private IQueryable<MassMediaPost> GetMassMediaPosts()
        {
            return DB.MassMediaPosts.IncludeAvailability()
                                    .Include(o => o.Localizations)
                                    .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }
        #endregion
    }
}
