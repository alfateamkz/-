using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways.Models.Messages;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Exceptions;
using Alfateam.Website.API.Filters;
using Alfateam.Website.API.Helpers;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.UserModels;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Roles;
using Alfateam2._0.Models.Shop.Orders;
using Alfateam2._0.Models.Shop.Wishes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Alfateam.Website.API.Controllers.General
{
    public class UsersController : AbsController
    {


        public UsersController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("Login")]
        public async Task<string> Login(string email,string password)
        {
            var user = DB.Users.ToList()
                               .FirstOrDefault(o => o.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                                && PasswordHelper.CheckEncryptedPassword(password, o.Password));

            if(user == null)
            {
                throw new Exception404("Неверный логин или пароль");

            }

            var session = new Session
            {
                User = user,
            };
            DbService.CreateEntity(DB.Sessions, session);

            return session.SessID;
        }


        [HttpGet, Route("GetUserBySessionToken")]
        [UserActionsFilter]
        public async Task<UserDTO> GetUserBySessionToken()
        {
            return (UserDTO)new UserDTO().CreateDTO(this.Session.User);
        }





        [HttpPost, Route("RegisterUser")]
        public async Task<UserDTO> RegisterUser(RegisterUserModel model)
        {
            if (model.RegisteredFromCountryId == null)
            {
                throw new Exception400("Необходимо указать id страны, из которой зарегистрирован пользователь");
            }
            else if (model.CountryId == null)
            {
                throw new Exception400("Необходимо указать id страны, в которой находится пользователь");
            }
            else if(DB.Users.ToList().Any(o => o.Email.Equals(model.Email,StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception400("Пользователь с данным email уже зарегистрирован");
            }

            return (UserDTO)DbService.TryCreateEntity(DB.Users, model, (entity) =>
            {
                entity.Password = PasswordHelper.EncryptPassword(model.Password);
                entity.RoleModel = UserRoleModel.CreateDefault();
                entity.Wishlist = new ShopWishlist();
            });
        }







        [HttpPut, Route("UpdateUser")]
        [UserActionsFilter]
        public async Task<UpdateUserModel> UpdateUser(UpdateUserModel model)
        {
            return (UpdateUserModel)DbService.TryUpdateEntity(DB.Users, model, this.Session.User);
        }


        [HttpPut, Route("UploadAvatar")]
        [UserActionsFilter]
        [SwaggerOperation(description: "Нужно загрузить аватар через форму с именем avatar")]
        public async Task<string> UploadAvatar()
        {
            const string formFilename = "avatar";

            var user = this.Session.User;
            user.AvatarPath = await FilesService.TryUploadFile(formFilename, Enums.FileType.Image);
            DbService.UpdateEntity(DB.Users, user);

            return this.Session.User.AvatarPath;
        }





        [HttpPut, Route("ChangePassword")]
        [UserActionsFilter]
        public async Task ChangePassword(string oldPwd, string newPwd)
        {
            var session = this.Session;
            var user = session.User;

            if(!PasswordHelper.CheckEncryptedPassword(oldPwd, user.Password))
            {
                throw new Exception403("Старый пароль не совпадает");
            }
            else if (string.IsNullOrEmpty(newPwd))
            {
                throw new Exception400("Укажите новый пароль");
            }
            else if (newPwd.Length < 8)
            {
                throw new Exception400("Длина пароля должна быть не менее 8 символов");
            }

            user.Password = PasswordHelper.EncryptPassword(newPwd);
            DB.Users.Update(user);

            var otherSessions = DB.Sessions.Where(o => o.UserId == user.Id && o.Id != session.Id);
            foreach (var otherSession in otherSessions)
            {
                otherSession.IsDeactivated = true;
            }
            DB.Sessions.UpdateRange(otherSessions);
            DB.SaveChanges();
        }


        [HttpPut, Route("ResetPassword")]
        public async Task ResetPassword(string email)
        {
            var found = DB.Users.FirstOrDefault(o => o.Email == email);
            if (found == null)
            {
                throw new Exception404("Пользователь не найден");
            }

            var pwd = PasswordHelper.GeneratePassword(12);
            found.Password = PasswordHelper.EncryptPassword(pwd);

            var sessions = DB.Sessions.Where(o => o.UserId == found.Id);
            foreach (var session in sessions)
            {
                session.IsDeactivated = true;
            }
            DB.Sessions.UpdateRange(sessions);

            DB.Users.Update(found);
            DB.SaveChanges();

            //TODO: 1. Красиво оформить письмо. 2. Локализации писем
            MailGateway.SendRestoreMail(new EmailMessage
            {
                Subject = "Восстановление пароля",
                Body = $"Ваш новый пароль : {pwd}",
                ToDisplayName = $"{found.Name} {found.Surname}",
                ToEmail = found.Email
            });
        }
    }
}
