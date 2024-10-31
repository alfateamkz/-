using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Messenger.API.Controllers.Owner
{
    public class UsersController : AbsController
    {
        public UsersController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetUsers")]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = DB.Users.Include(o => o.Permissions)
                                .Include(o => o.AllowedAccountsAccess)
                                .Include(o => o.Permissions)
                                .Include(o => o.TrustedUserIPs)
                                .Where(o => o.CompanyWorkSpaceId == this.WorkspaceID && !o.IsDeleted);
            return new UserDTO().CreateDTOs(users, IDDB.Users);
        }

        [HttpGet, Route("GetUser")]
        public async Task<UserDTO> GetUser(int id)
        {
            var users = DB.Users.Include(o => o.Permissions)
                                .Include(o => o.AllowedAccountsAccess)
                                .Include(o => o.Permissions)
                                .Include(o => o.TrustedUserIPs)
                                .Where(o => o.CompanyWorkSpaceId == this.WorkspaceID && !o.IsDeleted);

            var user = DBService.TryGetOne(users, id);
            return new UserDTO().CreateDTO(user, IDDB.Users.FirstOrDefault(o => o.Guid == user.AlfateamID));
        }




        [HttpPost, Route("CreateUser")]
        public async Task<UserDTO> CreateUser(UserDTO model)
        {
            var alfateamIDUser = IDDB.Users.FirstOrDefault(o => o.Email == model.Email);
            if (alfateamIDUser != null)
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
            var users = DB.Users.Where(o => o.CompanyWorkSpaceId == this.WorkspaceID && !o.IsDeleted);
            var user = DBService.TryGetOne(users, model.Id);

            return (UserDTO)DBService.TryUpdateEntity(DB.Users, model, user);
        }



        [HttpDelete, Route("DeleteUser")]
        public async Task DeleteUser(int id)
        {
            var users = DB.Users.Where(o => o.CompanyWorkSpaceId == this.WorkspaceID && !o.IsDeleted);
            var user = DBService.TryGetOne(users, id);

            DBService.TryDeleteEntity(DB.Users, user);
        }
    }
}
