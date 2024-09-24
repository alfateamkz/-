using Alfateam.CRM2_0.Models.General;
using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Models;
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
        public ReviewsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetReviews")]
        public async Task<IEnumerable<ReviewDTO>> GetReviews(int offset, int count = 20)
        {
            var reviews = DB.Reviews.Include(o => o.User)
                                    .Where(o => !o.IsDeleted && o.CountryId == CountryId)
                                    .Skip(offset)
                                    .Take(count)
                                    .ToList();

            return new ReviewDTO().CreateDTOsWithLocalization(reviews, this.LanguageId).Cast<ReviewDTO>();
        }



        [HttpGet, Route("GetMyReviews")]
        [UserActionsFilter]
        public async Task<IEnumerable<ReviewDTO>> GetMyReviews()
        {
            var user = DB.Sessions.IgnoreAutoIncludes().Include(o => o.User).ThenInclude(o => o.Reviews)
                                  .FirstOrDefault(o => o.SessID == UserSessid)
                                  .User;

            return new ReviewDTO().CreateDTOsWithLocalization(user.Reviews, this.LanguageId).Cast<ReviewDTO>();
        }

        [HttpPost, Route("CreateReview")]
        [UserActionsFilter]
        public async Task<ReviewDTO> CreateReview(ReviewDTO model)
        {
            return (ReviewDTO)DbService.TryCreateEntity(DB.Reviews, model, (entity) =>
            {
                entity.UserId = (int)GetUserIdIfSessionValid();
            });
        }

        [HttpPut, Route("UpdateReview")]
        [UserActionsFilter]
        public async Task<ReviewDTO> UpdateReview(ReviewDTO model)
        {
            var review = DB.Reviews.FirstOrDefault(o => o.Id == model.Id);
            return (ReviewDTO)DbService.TryUpdateEntity(DB.Reviews, model, review, (entity) =>
            {
                if(entity.UserId != GetUserIdIfSessionValid())
                {
                    throw new Exception403("Отзыв не принадлежит текущему пользователю");
                }
            });
        }

        [HttpDelete, Route("DeleteReview")]
        [UserActionsFilter]
        public async Task DeleteReview(int id)
        {
            var review = DB.Reviews.FirstOrDefault(o => o.Id == id);
            if(review == null)
            {
                throw new Exception404("Сущность с данным id не найдена");
            }
            else if (review.UserId != GetUserIdIfSessionValid())
            {
                throw new Exception403("Отзыв не принадлежит текущему пользователю");
            }

            DbService.DeleteEntity(DB.Reviews, review);
        }
    }
}
