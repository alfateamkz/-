using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Models.DTO.Shop.Orders;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Reviews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminReviewsController : AbsAdminController
    {
        public AdminReviewsController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }

        #region Отзывы

        [HttpGet, Route("GetReviews")]
        public async Task<RequestResult<IEnumerable<Review>>> GetReviews(int offset, int count = 20)
        {
            var checkAccessResult = CheckAccess(1);
            if (!checkAccessResult.Success)
            {
                return new RequestResult<IEnumerable<Review>>().FillFromRequestResult(checkAccessResult);
            }

            var user = GetSessionWithRoleInclude().User;
            var reviews = GetAvailableReviews(user, offset, count);
            return RequestResult<IEnumerable<Review>>.AsSuccess(reviews);
        }


        [HttpGet, Route("GetReview")]
        public async Task<RequestResult<Review>> GetReview(int id)
        {
            var user = GetSessionWithRoleInclude()?.User;
            var item = GetAvailableReviews(user).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<Review>(new Func<RequestResult>[]
            {
                () => CheckAccess(1),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () => RequestResult<Review>.AsSuccess(item)
            });
        }


        [HttpPut, Route("SetReviewHidden")]
        public async Task<RequestResult<Review>> SetReviewHidden(int id,bool val)
        {
            var user = GetSessionWithRoleInclude()?.User;
            var item = GetAvailableReviews(user).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<Review>(new Func<RequestResult>[]
            {
                () => CheckAccess(2),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () =>
                {
                    item.IsHidden = val;
                    return UpdateModel(DB.Reviews,item);
                }
            });
        }

        [HttpDelete, Route("DeleteReview")]
        public async Task<RequestResult<Review>> DeleteReview(int id)
        {
            var user = GetSessionWithRoleInclude()?.User;
            var item = GetAvailableReviews(user).FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            return TryFinishAllRequestes<Review>(new Func<RequestResult>[]
            {
                () => CheckAccess(3),
                () => RequestResult.FromBoolean(item != null, 404, "Сущность по данному id не найдена"),
                () => DeleteModel(DB.Reviews, item)
            });
        }

        #endregion




        #region Private check access methods

        private RequestResult CheckAccess(int requiredLevel)
        {
            var session = GetSessionWithRoleInclude();
            return TryFinishAllRequestes(new Func<RequestResult>[]
            {
                () => RequestResult.FromBoolean(session.User.RoleModel.Role != UserRole.User,
                        403, "У данного пользователя нет доступа в администраторскую панель"),
                () => CheckSession(session),
                () => RequestResult.FromBoolean(session.User.RoleModel.ReviewsAccess.AccessLevel >= requiredLevel || session.User.RoleModel.Role == UserRole.Owner,
                       403, "У данного пользователя нет прав на выполнение данного действия")
             });
        }

        #endregion

        #region Private get available reviews

        private List<Review> GetAvailableReviews(User user)
        {
            var allReviews = GetReviewsList();
            var availableReviews = new List<Review>();

            if (user.RoleModel.Role == UserRole.Owner)
            {
                return allReviews.ToList();
            }

            foreach (var review in allReviews)
            {
                if (user.RoleModel.IsAllCountriesAccess)
                {
                    bool isForbidden = false;

                    foreach (var country in user.RoleModel.ForbiddenCountries)
                    {
                        if (review.CountryId == country.Id)
                        {
                            isForbidden = true;
                            break;
                        }
                    }

                    if (!isForbidden)
                    {
                        availableReviews.Add(review);
                    }
                }
                else
                {
                    foreach (var country in user.RoleModel.AvailableCountries)
                    {
                        if (review.CountryId == country.Id)
                        {
                            availableReviews.Add(review);
                            break;
                        }
                    }

                }
            }


            return availableReviews;
        }
        private List<Review> GetAvailableReviews(User user, int offset, int count = 20)
        {
            return GetAvailableReviews(user).Skip(offset).Take(count).ToList();
        }


        #endregion

        #region Private get included methods

        private IQueryable<Review> GetReviewsList()
        {
            return DB.Reviews.Include(o => o.Country)
                             .Include(o => o.User)
                             .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
