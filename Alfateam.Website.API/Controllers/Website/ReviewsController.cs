using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Models.DTO.HR;
using Alfateam.Website.API.Models.DTO.Reviews;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.HR;
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
                             .Where(o => !o.IsDeleted && o.CountryId == CountryId)
                             .Skip(offset)
                             .Take(count)
                             .ToList();
        }



        [HttpGet, Route("GetMyReviews"), UserActionsFilter]
        public async Task<RequestResult<IEnumerable<Review>>> GetMyReviews()
        {

            var session = DB.Sessions.IgnoreAutoIncludes().Include(o => o.User).ThenInclude(o => o.Reviews)
                                     .FirstOrDefault(o => o.SessID == UserSessid);
            var checkSessionResult = CheckSession(session);
            if(checkSessionResult != null)
            {
                return new RequestResult<IEnumerable<Review>>().FillFromRequestResult(checkSessionResult);
            }
            return RequestResult<IEnumerable<Review>>.AsSuccess(session.User.Reviews);
        }

        [HttpPost, Route("CreateReview"), UserActionsFilter]
        public async Task<RequestResult<Review>> CreateReview(Review review)
        {
            var session = DB.Sessions.IgnoreAutoIncludes().Include(o => o.User).ThenInclude(o => o.Reviews)
                                     .FirstOrDefault(o => o.SessID == UserSessid);

            return TryFinishAllRequestes<Review>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(review.IsValid(), 400, "Проверьте корректность заполненных значений"),
                () =>
                {
                    session.User.Reviews.Add(review);
                    DB.Users.Update(session.User);
                    DB.SaveChanges();
                    return RequestResult<Review>.AsSuccess(review);
                }
            });
        }

        [HttpPut, Route("UpdateReview"), UserActionsFilter]
        public async Task<RequestResult<Review>> UpdateReview(ReviewDTO model)
        {
            var review = DB.Reviews.FirstOrDefault(o => o.Id == model.Id);
            var session = DB.Sessions.FirstOrDefault(o => o.SessID == UserSessid);
            return TryFinishAllRequestes<Review>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(review != null, 404,"Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(review.UserId == session.User.Id, 403, "Сущность не принадлежит текущему пользователю"),
                () =>
                {
                    model.FillDBModel(review, DBModelFillMode.Update);
                    DB.Reviews.Update(review);
                    DB.SaveChanges();
                    return RequestResult<Review>.AsSuccess(review);
                }
            });
        }

        [HttpDelete, Route("DeleteReview"), UserActionsFilter]
        public async Task<RequestResult> DeleteReview(int id)
        {
            var review = DB.Reviews.FirstOrDefault(o => o.Id == id);
            var session = DB.Sessions.FirstOrDefault(o => o.SessID == UserSessid);

            return TryFinishAllRequestes(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(review != null, 404,"Сущность с данным id не найдена"),
                () => RequestResult.FromBoolean(review.UserId == session.User.Id, 403, "Сущность не принадлежит текущему пользователю"),
                () =>
                {
                    review.IsDeleted = true;
                    DB.Reviews.Update(review);
                    DB.SaveChanges();
                    return RequestResult.AsSuccess();
                }
            });
        }
    }
}
