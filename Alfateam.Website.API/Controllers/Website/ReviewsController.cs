using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.Core;
using Alfateam2._0.Models.Reviews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Website
{
    public class ReviewsController : AbsController
    {
        public ReviewsController(WebsiteDBContext db) : base(db)
        {
        }

        [HttpGet, Route("GetReviews")]
        public async Task<IEnumerable<Review>> GetReviews(int offset, int count = 20)
        {
            return DB.Reviews.Include(o => o.User)
                             .Where(o => !o.IsDeleted)
                             .Skip(offset)
                             .Take(count)
                             .ToList();
        }



        [HttpPost, Route("AddReview")]
        public async Task<RequestResult> AddReview(Review review)
        {
            try
            {
                review.PublishedAt = DateTime.UtcNow;

                DB.Reviews.Add(review);
                DB.SaveChanges();

                return RequestResult.AsSuccess();
            }
            catch
            {
                return RequestResult.AsError(400, "Неверно заполнены поля");
            }
        }
    }
}
