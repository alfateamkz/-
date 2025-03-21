﻿using Alfateam.Core.Exceptions;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.General.PowersOfAttorney;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Controllers.Director
{
    [MustBeCompany]
    [RequiredRole(UserRole.Owner)]
    public class PowersOfAttorneyController : AbsAuthorizedController
    {
        public PowersOfAttorneyController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetUserPOA")]
        public async Task<PowerOfAttorneyDTO> GetUserPOA(int userId)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), userId);
            return (PowerOfAttorneyDTO)new PowerOfAttorneyDTO().CreateDTO(user.PowerOfAttorney);
        }

        [HttpPost, Route("SendPOAToModeration")]
        public async Task<PowerOfAttorneyDTO> SendPOAToModeration(int userId, PowerOfAttorneyDTO model)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), userId);
            if (user.PowerOfAttorneyId != null)
            {
                throw new Exception400("У пользователя уже имеется прикрепленная доверенность");
            }

            return (PowerOfAttorneyDTO)DBService.TryCreateEntity(DB.PowersOfAttorney, model, (entity) =>
            {
                entity.UserId = userId;
            });
        }

        [HttpDelete, Route("RemovePOA")]
        public async Task RemovePOA(int userId)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), userId);
            if (user.PowerOfAttorneyId == null)
            {
                throw new Exception400("У пользователя нет прикрепленной доверенности");
            }
            user.PowerOfAttorneyId = null;
            DBService.UpdateEntity(DB.Users, user);
        }




        #region Private methods
        private IEnumerable<User> GetAvailableUsers()
        {
            return DB.Users.Include(o => o.PowerOfAttorney)
                           .Where(o => o.CompanyId == this.EDMSubjectId && !o.IsDeleted);
        }


        #endregion
    }
}
