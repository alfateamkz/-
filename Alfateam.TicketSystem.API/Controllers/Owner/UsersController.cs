using Alfateam.TicketSystem.Models.General;
using Alfateam.TicketSystem.API.Abstractions;
using Alfateam.TicketSystem.API.Models;
using Alfateam.TicketSystem.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.TicketSystem.Models.Enums;
using Alfateam.TicketSystem.API.Filters;

namespace Alfateam.TicketSystem.API.Controllers.Owner
{
    [Route("Owner/[controller]")]
    [RequiredRole(UserRole.Owner)]
    public class UsersController : AbsAuthorizedController
    {
        public UsersController(ControllerParams @params) : base(@params)
        {
        }

        #region CRUD операции с пользователями 

        [HttpGet, Route("GetUsers")]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return new UserDTO().CreateDTOs(GetAvailableUsers(), IDDB.Users);
        }

        [HttpGet, Route("GetUser")]
        public async Task<UserDTO> GetUser(int id)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), id);
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
                    entity.BusinessCompanyId = (int)this.CompanyId;
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
                           .Include(o => o.Department)
                           .Where(o => o.BusinessCompanyId == this.CompanyId && !o.IsDeleted);
        }

        #endregion
    }
}
