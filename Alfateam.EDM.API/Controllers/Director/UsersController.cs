using Alfateam.EDM.API.Abstractions;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Controllers.Director
{
    [RequiredRole(UserRole.Owner)]
    public class UsersController : AbsAuthorizedController
    {
        public UsersController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetCompanyUsers")]
        public async Task<IEnumerable<UserDTO>> GetCompanyUsers()
        {
            var users = DB.Companies.Include(o => o.Users).ThenInclude(o => o.Permissions)
                                    .Include(o => o.Users).ThenInclude(o => o.DocumentsAccess)
                                    .Include(o => o.Users).ThenInclude(o => o.NotificationSettings)
                                    .Include(o => o.Users).ThenInclude(o => o.TrustedUserIPs)
                                    .FirstOrDefault(o => o.Id == this.CompanyId && o.BusinessId == this.BusinessId)
                                    ?.Users;

            return new UserDTO().CreateDTOs(users, IDDB.Users);
        }

        [HttpGet, Route("GetCompanyUser")]
        public async Task<UserDTO> GetCompanyUser(int id)
        {
            var users = DB.Companies.Include(o => o.Users).ThenInclude(o => o.Permissions)
                                   .Include(o => o.Users).ThenInclude(o => o.DocumentsAccess)
                                   .Include(o => o.Users).ThenInclude(o => o.NotificationSettings)
                                   .Include(o => o.Users).ThenInclude(o => o.TrustedUserIPs)
                                   .FirstOrDefault(o => o.Id == this.CompanyId && o.BusinessId == this.BusinessId)
                                   ?.Users;

            var user = DBService.TryGetOne(users, id);
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
            var users = DB.Companies.FirstOrDefault(o => o.Id == this.CompanyId && o.BusinessId == this.BusinessId)?.Users;
            var user = DBService.TryGetOne(users, model.Id);

            return (UserDTO)DBService.TryUpdateEntity(DB.Users, model, user);
        }



        [HttpDelete, Route("DeleteUser")]
        public async Task DeleteUser(int id)
        {
            var users = DB.Companies.FirstOrDefault(o => o.Id == this.CompanyId && o.BusinessId == this.BusinessId)?.Users;
            var user = DBService.TryGetOne(users, id);

            DBService.TryDeleteEntity(DB.Users, user);
        }

    }
}
