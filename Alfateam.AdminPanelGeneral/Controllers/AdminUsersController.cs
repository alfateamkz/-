using Alfateam.Administration.Models.General;
using Alfateam.AdminPanelGeneral.API.Abstractions;
using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Administration.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.AdminPanelGeneral.API.Controllers
{
    public class AdminUsersController : AbsController
    {
        public AdminUsersController(ControllerParams @params) : base(@params)
        {
        }

        #region CRUD операции с пользователями 

        [HttpGet, Route("GetUsers")]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return new UserDTO().CreateDTOs(GetAvailableUsers(), IdDb.Users);
        }

        [HttpGet, Route("GetUser")]
        public async Task<UserDTO> GetUser(int id)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), id);
            return new UserDTO().CreateDTO(user, IdDb.Users.FirstOrDefault(o => o.Guid == user.AlfateamID));
        }




        [HttpPost, Route("CreateUser")]
        public async Task<UserDTO> CreateUser(UserDTO model)
        {
            var alfateamIDUser = IdDb.Users.FirstOrDefault(o => o.Email == model.Email);
            if (alfateamIDUser != null)
            {
                return (UserDTO)DBService.TryCreateEntity(AdmininstrationDb.Users, model, (entity) =>
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

            return (UserDTO)DBService.TryUpdateEntity(AdmininstrationDb.Users, model, user);
        }



        [HttpDelete, Route("DeleteUser")]
        public async Task DeleteUser(int id)
        {
            var user = DBService.TryGetOne(GetAvailableUsers(), id);

            DBService.TryDeleteEntity(AdmininstrationDb.Users, user);
        }

        #endregion








        #region Private methods
        private IEnumerable<User> GetAvailableUsers()
        {
            return AdmininstrationDb.Users.Include(o => o.RoleModel)
                                         .Where(o => !o.IsDeleted);
        }

        #endregion
    }
}
