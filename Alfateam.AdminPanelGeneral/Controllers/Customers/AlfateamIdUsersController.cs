using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.AdminPanelGeneral.API.Models.Filters.Customers;
using Alfateam.Core;
using Alfateam.ID.Models;
using Alfateam.ID.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alfateam.AdminPanelGeneral.API.Controllers.Customers
{
    [Route("Customers/[controller]")]
    public class AlfateamIdUsersController : AbsController
    {
        public AlfateamIdUsersController(ControllerParams @params) : base(@params)
        {
        }

        #region Получение пользователей Alfateam ID

        [HttpGet, Route("GetUsers")]
        public async Task<ItemsWithTotalCount<UserDTO>> GetUsers(AlfateamIdUsersSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<User, UserDTO>(GetAvailableUsers(),filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.FIO.Contains(filter.Query)
                              || entity.Email.Contains(filter.Query)
                              || entity.Phone.Contains(filter.Query);
                }
                if (!string.IsNullOrEmpty(filter.CountryCode))
                {
                    condition &= entity.CountryCode == filter.CountryCode;
                }
                if (!string.IsNullOrEmpty(filter.LanguageCode))
                {
                    condition &= entity.CountryCode == filter.LanguageCode;
                }
                if(filter.HasAnySuccessfulPayment != null)
                {
                    condition &= filter.HasAnySuccessfulPayment == entity.Payments.Any(o => o.PaidAt != null);
                }

                return condition;
            });
        }

        [HttpGet, Route("GetUser")]
        public async Task<UserDTO> GetUser(int id)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), id);
            return (UserDTO)new UserDTO().CreateDTO(user);
        }

        #endregion





        #region Private methods
        private IEnumerable<User> GetAvailableUsers()
        {
            return IdDb.Users.Include(o => o.Payments)
                             .Include(o => o.PaymentWays)
                             .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
