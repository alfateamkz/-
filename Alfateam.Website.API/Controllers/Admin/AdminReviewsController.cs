using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Core.Exceptions;
using Alfateam.Website.API.Filters.Access;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.HR;
using Alfateam.Website.API.Models.DTO.Reviews;
using Alfateam.Website.API.Models.DTO.Shop.Orders;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Reviews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.Website.API.Filters.AdminSearch;
using Alfateam.Website.API.Models.Filters.Admin.AdminSearch;
using Alfateam.Website.API.Models.DTO;
using Alfateam.Core;

namespace Alfateam.Website.API.Controllers.Admin
{
    public class AdminReviewsController : AbsAdminController
    {
        public AdminReviewsController(ControllerParams @params) : base(@params)
        {
        }

        #region Отзывы



        [HttpGet, Route("GetReviews")]
        [ReviewsSectionAccess(1)]
        public async Task<ItemsWithTotalCount<ReviewDTO>> GetReviews(int offset, int count = 20)
        {
            return DbService.GetManyWithTotalCount<Review, ReviewDTO>(GetAvailableReviews(), offset, count);
        }

        [HttpGet, Route("GetReviewsFiltered")]
        [ReviewsSectionAccess(1)]
        public async Task<ItemsWithTotalCount<ReviewDTO>> GetReviewsFiltered([FromQuery] ReviewsSearchFilter filter)
        {
            return DbService.GetManyWithTotalCount<Review, ReviewDTO>(filter.Filter(GetAvailableReviews()), filter.Offset, filter.Count, (entity) =>
            {
                return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
            });
        }


        [HttpGet, Route("GetReview")]
        [ReviewsSectionAccess(1)]
        public async Task<ReviewDTO> GetReview(int id)
        {
            return (ReviewDTO)DbService.TryGetOne(GetAvailableReviews(), id, new ReviewDTO());
        }


        [HttpPut, Route("SetReviewHidden")]
        [ReviewsSectionAccess(2)]
        public async Task SetReviewHidden(int id,bool val)
        {
            var item = GetAvailableReviews().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if(item == null)
            {
                throw new Exception404("Сущность по данному id не найдена");
            }

            item.IsHidden = val;
            DbService.UpdateEntity(DB.Reviews, item);
        }



        [HttpDelete, Route("DeleteReview")]
        [ReviewsSectionAccess(3)]
        public async Task DeleteReview(int id)
        {
            var item = GetAvailableReviews().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DbService.TryDeleteEntity(DB.Reviews, item);
        }

        #endregion




        #region Private get available reviews

        private List<Review> GetAvailableReviews()
        {
            var allReviews = GetReviewsList();
            var availableReviews = new List<Review>();

            var user = this.Session.User;

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
        private List<Review> GetAvailableReviews(int offset, int count = 20)
        {
            return GetAvailableReviews().Skip(offset).Take(count).ToList();
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
