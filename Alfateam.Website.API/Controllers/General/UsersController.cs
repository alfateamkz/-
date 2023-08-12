using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways.Models.Messages;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Helpers;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.Core;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Roles;
using Alfateam2._0.Models.Shop.Orders;
using Alfateam2._0.Models.Shop.Wishes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.General
{
    public class UsersController : AbsController
    {
        private readonly IMailGateway MailGateway;
        public UsersController(WebsiteDBContext db, IWebHostEnvironment appEnv, IMailGateway mailGateway) : base(db, appEnv)
        {
            MailGateway = mailGateway;
        }

        [HttpGet, Route("Login")]
        public AuthResponseModel Login(string email,string password)
        {
            var res = new AuthResponseModel();


            var user = DB.Users
                .Include(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                .Include(o => o.Country)
                .FirstOrDefault(o => o.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                                && PasswordHelper.CheckEncryptedPassword(password, o.Password));

            if(user != null)
            {
                var session = new Session
                {
                    User = user,
                };
                DB.Sessions.Add(session);
                DB.SaveChanges();

                res.User = user;
                res.Sessid = session.SessID;
            }

            return res;
        }


        [HttpGet, Route("GetUserBySessionToken")]
        public RequestResult<User> GetUserBySessionToken()
        {
            var res = new RequestResult<User>();

            var sessionUser = GetUserBySessid();

            if (sessionUser.Session == null)
            {
                res.Code = 404;
                res.Error = "Токен не найден в системе";
            }
            else if(sessionUser.Session.ExpiresAt >= DateTime.UtcNow)
            {
                res.Code = 403;
                res.Error = "Срок действия токена закончился";
            }
            else
            {
                res.Value = sessionUser.User;
                res.Success = true;
            }

            return res;
        }





        [HttpPost, Route("RegisterUser")]
        public RequestResult<User> RegisterUser(User user)
        {
            var res = new RequestResult<User>();

            if (user.Id != 0)
            {
                res.Code = 400;
                res.Error = "Невозможно создать пользователя с явно заданным идентификатором";
            }
            if (user.RegisteredFromCountryId == null)
            {
                res.Code = 400;
                res.Error = "Необходимо указать id страны, из которой зарегистрирован пользователь";
            }
            if (user.Country == null)
            {
                res.Code = 400;
                res.Error = "Необходимо указать id страны, в которой находится пользователь";
            }
            if (DB.Users.Any(o => o.Email.Equals(user.Email,StringComparison.OrdinalIgnoreCase)))
            {
                res.Code = 400;
                res.Error = "Пользователь с данным email уже зарегистрирован";
            }
            else
            {
                user.Password = PasswordHelper.EncryptPassword(user.Password);
                user.RoleModel = new UserRoleModel();

                user.Wishlist = new ShopWishlist();
                user.Basket = new ShopOrder();

                res.Success = true;
                res.Value = user;
            }


            return res;
        }







        [HttpPut, Route("UpdateUser")]
        public RequestResult<User> UpdateUser(UpdateUserModel model)
        {
            var res = new RequestResult<User>();

            var found = DB.Users.FirstOrDefault(o => o.Id == model.Id);
            if (found == null)
            {
                res.Code = 404;
                res.Error = "Пользователь не найден";
            }
            else if (!model.ValidateModel())
            {
                res.Code = 400;
                res.Error = "Заполните необходимые данные";
            }
            else
            {
                model.SetData(found);

                DB.Users.Update(found);
                DB.SaveChanges();

                res.Success = true;
            }

            return res;
        }


        [HttpPut, Route("UploadAvatar")]
        public async Task<RequestResult<User>> UploadAvatar()
        {
            var res = new RequestResult<User>();

            var session = DB.Sessions.Include(o => o.User).FirstOrDefault(o => o.SessID == this.UserSessid);

            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                res.FillFromRequestResult(checkSessionRes);
            }
            else
            {
                var file = Request.Form.Files.FirstOrDefault();
                if(file == null)
                {
                    res.Code = 400;
                    res.Error = "Необходимо загрузить аватар";
                }
                else if (file.Length == 0)
                {
                    res.Code = 400;
                    res.Error = "Пустой файл";
                }
                else if (!this.IsImageFileExtension(file.FileName))
                {
                    res.Code = 400;
                    res.Error = "Неподдерживаемый формат файла";
                }
                else
                {
                    session.User.AvatarPath = await this.UploadFile(file);

                    DB.Users.Update(session.User);
                    DB.SaveChanges();

                    res.Success = true;
                }         
            }

            return res;
        }





        [HttpPut, Route("ChangePassword")]
        public RequestResult<User> ChangePassword(int id, string oldPwd, string newPwd)
        {
            var res = new RequestResult<User>();

            var found = DB.Users.FirstOrDefault(o => o.Id == id);
            if (found == null)
            {
                res.Code = 404;
                res.Error = "Пользователь не найден";
            }
            else if (!PasswordHelper.CheckEncryptedPassword(oldPwd, found.Password))
            {
                res.Code = 403;
                res.Error = "Старый пароль не совпадает";
            }
            else if (newPwd == null)
            {
                res.Code = 400;
                res.Error = "Укажите новый пароль";
            }
            else if (newPwd.Length < 8)
            {
                res.Code = 400;
                res.Error = "Длина пароля должна быть не менее 8 символов";
            }
            else
            {
                found.Password = PasswordHelper.EncryptPassword(newPwd);
                DB.Users.Update(found);
                DB.SaveChanges();

                res.Success = true;
            }

            return res;
        }

        [HttpPut, Route("ResetPassword")]
        public RequestResult ResetPassword(int id)
        {
            var res = new RequestResult();

            var found = DB.Users.FirstOrDefault(o => o.Id == id);
            if (found == null)
            {
                res.Code = 404;
                res.Error = "Пользователь не найден";
            }
            else
            {
                var pwd = PasswordHelper.GeneratePassword(12);
                found.Password = PasswordHelper.EncryptPassword(pwd);

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

                res.Success = true;
            }

            return res;
        }
    }
}
