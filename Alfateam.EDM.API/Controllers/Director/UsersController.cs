using Alfateam.Core;
using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alfateam.EDM.API.Controllers.Director
{
    [MustBeCompany]
    [RequiredRole(UserRole.Owner)]
    public class UsersController : AbsAuthorizedController
    {
        public UsersController(ControllerParams @params) : base(@params)
        {
        }

        #region Пользователи компании

        [HttpGet, Route("GetCompanyUsers")]
        public async Task<ItemsWithTotalCount<UserDTO>> GetCompanyUsers([FromQuery] SearchFilter filter)
        {
            var users = new UserDTO().CreateDTOs(GetAvailableUsers(), IDDB.Users).Cast<UserDTO>();
            if(filter.Query != null)
            {
                users = users.Where(o => o.FIO.Contains(filter.Query, StringComparison.OrdinalIgnoreCase));
            }

            return new ItemsWithTotalCount<UserDTO>()
            {
                Items = users.Skip(filter.Offset).Take(filter.Count).ToList(),
                TotalCount = users.Count()
            };
        }

        [HttpGet, Route("GetCompanyUser")]
        public async Task<UserDTO> GetCompanyUser(int id)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), id);
            return new UserDTO().CreateDTO(user, IDDB.Users.FirstOrDefault(o => o.Guid == user.AlfateamID));
        }




        [HttpPost, Route("CreateUser")]
        public async Task<UserDTO> CreateUser(UserDTO model)
        {
            var alfateamIDUser = IDDB.Users.FirstOrDefault(o => o.Email == model.Email);
            if(alfateamIDUser != null)
            {
                return (UserDTO)DBService.TryCreateEntity(DB.Users, model, (entity) =>
                {
                    entity.AlfateamID = alfateamIDUser.Guid;
                });
            }
            else
            {
                //TODO: сделать отправку письма на почту с последующей регистрацией в Alfateam ID и после регистрации установить AlfateamID
                throw new NotImplementedException();
            }
        }




        [HttpPut, Route("UpdateUser")]
        public async Task<UserDTO> UpdateUser(UserDTO model)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), model.Id);
            return (UserDTO)DBService.TryUpdateEntity(DB.Users, model, user);
        }



        [HttpDelete, Route("DeleteUser")]
        public async Task DeleteUser(int id)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), id);
            DBService.TryDeleteEntity(DB.Users, user);
        }

        #endregion






        #region Private methods
        private IEnumerable<User> GetAvailableUsers()
        {
            return DB.Users.Include(o => o.Permissions)
                           .Include(o => o.DocumentsAccess)
                           .Include(o => o.NotificationSettings)
                           .Include(o => o.TrustedUserIPs)
                           .Where(o => o.CompanyId == this.EDMSubjectId && !o.IsDeleted);
        }


        #endregion

    }
}
