using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways.Models.Messages;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Core;
using Alfateam.Website.API.Helpers;
using Alfateam.Website.API.Models.UserModels;
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


            var sdfsf = DB.Users
                .Include(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                .Include(o => o.Country)
                .ToList();

            var user = DB.Users
                .Include(o => o.RoleModel).ThenInclude(o => o.AvailableCountries)
                .Include(o => o.Country)
                .ToList()
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
            else if(sessionUser.Session.ExpiresAt < DateTime.UtcNow)
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
        public RequestResult<User> RegisterUser(RegisterUserModel model)
        {
            var res = new RequestResult<User>();

            if (model.RegisteredFromCountryId == null)
            {
                res.Code = 400;
                res.Error = "Необходимо указать id страны, из которой зарегистрирован пользователь";
            }
            if (model.CountryId == null)
            {
                res.Code = 400;
                res.Error = "Необходимо указать id страны, в которой находится пользователь";
            }
            if (DB.Users.ToList().Any(o => o.Email.Equals(model.Email,StringComparison.OrdinalIgnoreCase)))
            {
                res.Code = 400;
                res.Error = "Пользователь с данным email уже зарегистрирован";
            }
            else
            {
                var user = new User();
                model.SetData(user);

                user.Password = PasswordHelper.EncryptPassword(user.Password);
                user.RoleModel = UserRoleModel.CreateDefault();

                user.Wishlist = new ShopWishlist();

                DB.Users.Add(user);
                DB.SaveChanges();



                user.Wishlist.User = null;


                res.Success = true;
                res.Value = user;
            }


            return res;
        }







        [HttpPut, Route("UpdateUser")]
        public async Task<RequestResult<User>> UpdateUser(UpdateUserModel model)
        {
            var session = DB.Sessions.Include(o => o.User).FirstOrDefault(o => o.SessID == this.UserSessid);
            return TryFinishAllRequestes<User>(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(session.User != null,404,"Пользователь не найден"),
                () =>
                {
                    model.Id = session.UserId;
                    return RequestResult.FromBoolean(model.ValidateModel(),400,"Заполните необходимые данные");
                },
                () =>
                {
                    model.SetData(session.User);
                    DB.Users.Update(session.User);
                    DB.SaveChanges();
                    return RequestResult<User>.AsSuccess(session.User);
                }
            });
        }


        [HttpPut, Route("UploadAvatar")]
        public async Task<RequestResult<User>> UploadAvatar()
        {
            var session = DB.Sessions.Include(o => o.User).FirstOrDefault(o => o.SessID == this.UserSessid);
            var checkSessionRes = CheckSession(session);
            if (!checkSessionRes.Success)
            {
                return new RequestResult<User>().FillFromRequestResult(checkSessionRes);
            }
            else
            {
                var uploadRes = await TryUploadFile("avatar", Enums.FileType.Image);
                if(!uploadRes.Success)
                {
                    return new RequestResult<User>().FillFromRequestResult(uploadRes);
                }

                session.User.AvatarPath = uploadRes.Value;
                DB.Users.Update(session.User);
                DB.SaveChanges();
                return RequestResult<User>.AsSuccess(session.User);
            }
        }





        [HttpPut, Route("ChangePassword")]
        public RequestResult ChangePassword(string oldPwd, string newPwd)
        {
            var session = DB.Sessions.Include(o => o.User).FirstOrDefault(o => o.SessID == this.UserSessid);
            return TryFinishAllRequestes(new[]
            {
                () => CheckSession(session),
                () => RequestResult.FromBoolean(PasswordHelper.CheckEncryptedPassword(oldPwd, session.User.Password),
                                                   403, "Старый пароль не совпадает"),
                () => RequestResult.FromBoolean(newPwd != null ,400, "Укажите новый пароль"),
                () => RequestResult.FromBoolean(newPwd.Length < 8 ,400, "Длина пароля должна быть не менее 8 символов"),
                () =>
                {
                    session.User.Password = PasswordHelper.EncryptPassword(newPwd);
                    DB.Users.Update(session.User);

                    var otherSessions = DB.Sessions.Where(o => o.UserId == session.UserId && o.Id != session.Id);
                    foreach(var otherSession in otherSessions)
                    {
                        otherSession.IsDeactivated = true;
                    }
                    DB.Sessions.UpdateRange(otherSessions);

                    DB.SaveChanges();
                    return RequestResult.AsSuccess();
                }
            });
        }

        [HttpPut, Route("ResetPassword")]
        public RequestResult ResetPassword(string email)
        {
            var found = DB.Users.FirstOrDefault(o => o.Email == email);
            if (found == null)
            {
                return RequestResult.AsError(404, "Пользователь не найден");
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

            return RequestResult.AsSuccess();
        }
    }
}
