using Alfateam.Core.Exceptions;
using Alfateam.Core.Helpers;
using Alfateam.ID.Abstractions;
using Alfateam.ID.API.Filters;
using Alfateam.ID.API.Models;
using Alfateam.ID.Models.DTO;
using Alfateam.ID.Models;
using Alfateam.ID.Models.Abstractions;
using Alfateam.ID.Models.Enums;
using Alfateam.ID.Models.Security.Verifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Alfateam.DB.Services.Models;

namespace Alfateam.ID.API.Controllers
{
    public class AuthController : AbsController
    {
        public AuthController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetUserBySession")]
        [AuthorizedUser]
        public async Task<UserDTO> GetUserBySession()
        {
            return (UserDTO)new UserDTO().CreateDTO(this.Session.User);
        }

        [HttpPost, Route("Register")]
        public async Task<UserDTO> Register(UserDTO model)
        {
            if(DB.Users.Any(o => o.Email == model.Email))
            {
                throw new Exception400("Пользователь с данным email уже зарегистрирован");
            }
            else if (DB.Users.Any(o => o.Phone == model.Phone))
            {
                throw new Exception400("Пользователь с данным номером телефона уже зарегистрирован");
            }

            return (UserDTO)DBService.TryCreateEntity(DB.Users, model, (entity) =>
            {
                entity.Password = PasswordHelper.EncryptPassword(model.Password);
                model.Guid = entity.Guid;
            });
        }


        [HttpGet, Route("HasUserByEmailOrPhone")]
        public async Task<bool> HasUserByEmailOrPhone(string email, string phone)
        {
            return DB.Users.Any(o => o.Email == email || o.Phone == phone && !o.IsDeleted);
        }

        [HttpPut, Route("Refresh")]
        public async Task<AuthResultTokens> Refresh(string refreshToken)
        {
            var session = DB.Sessions.Include(o => o.User)
                                     .FirstOrDefault(o => o.RefreshToken == refreshToken);

            if(session == null)
            {
                throw new Exception404("Токен не найден");
            }
            else if (session.IsDeactivated)
            {
                throw new Exception403("Сессия была деактивирована");
            }
            else if (session.IsRefreshTokenUsed)
            {
                throw new Exception403("Токен уже был ранее использован");
            }

            session.IsRefreshTokenUsed = true;
            DBService.UpdateEntity(DB.Sessions, session);

            var newSession = CreateSession(session.User);
            return new AuthResultTokens
            {
                SessID = newSession.SessID,
                ExpiresAt = newSession.ExpiresAt,
                RefreshToken = newSession.RefreshToken,
            };
        }


        #region Авторизация

        [HttpPut, Route("AuthWithEmailAndPassword")]
        public async Task<AuthResultTokens> AuthWithEmailAndPassword(string email, string password)
        {
            var user = DB.Users.AsEnumerable().FirstOrDefault(o => o.Email == email
                                                                  && PasswordHelper.CheckEncryptedPassword(password, o.Password));
            if(user == null)
            {
                throw new Exception404("Неверный email или пароль");
            }

            var session = this.CreateSession(user);
            return new AuthResultTokens 
            {
                SessID = session.SessID,
                ExpiresAt = session.ExpiresAt,
                RefreshToken = session.RefreshToken,
            };
        }




        [HttpPut, Route("SendAuthCode")]
        public async Task SendAuthCode(VerificationType type, string contact)
        {
            GetUserThrowIfUserNotFound(type, contact);
            CodesService.SendCode(new AlfateamIDSendCodeParams
            {
                Type = type,
                Contact = contact,
                ActionFor = VerificationFor.Auth,
                LetterTitle = "Авторизация в Alfateam ID",
                MessageText = "Код для авторизации в Alfateam ID:",
            });
        }
    
        [HttpPut, Route("AuthWithCode")]
        public async Task<AuthResultTokens> AuthWithCode(VerificationType type, string contact, string code)
        {
            User user = GetUserThrowIfUserNotFound(type, contact);
            CodesService.VerifyCode(type, VerificationFor.Auth, contact, code);

            var session = this.CreateSession(user);
            return new AuthResultTokens
            {
                SessID = session.SessID,
                ExpiresAt = session.ExpiresAt,
                RefreshToken = session.RefreshToken,
            };
        }

        #endregion   

        #region Обязательная верификация телефона и email при регистрации

        [HttpPut, Route("SendRegisterVerificationCode")]
        [AuthorizedUser]
        public async Task SendRegisterVerificationCode(VerificationType type)
        {
            var user = this.Session.User;
            if(type == VerificationType.Phone && user.IsPhoneVerified)
            {
                throw new Exception403("Номер телефона уже верифицирован");
            }
            else if (type == VerificationType.Email && user.IsEmailVerified)
            {
                throw new Exception403("Email уже верифицирован");
            }

            CodesService.SendCode(new AlfateamIDSendCodeParams
            {
                Type = type,
                Contact = user.GetContact(type),
                ActionFor = VerificationFor.ContactVerification,
                LetterTitle = "Верификация в Alfateam ID",
                MessageText = "Код для верификации контакта в Alfateam ID:",
            });
        }


        [HttpPut, Route("VerifyRegisterContact")]
        [AuthorizedUser]
        public async Task VerifyRegisterContact(VerificationType type, string contact, string code)
        {
            var user = this.Session.User;

            CodesService.VerifyCode(type, VerificationFor.ContactVerification, contact, code);
            if (type == VerificationType.Phone)
            {
                user.IsPhoneVerified = true;
            }
            else if (type == VerificationType.Email)
            {
                user.IsEmailVerified = true;
            }

            DBService.UpdateEntity(DB.Users, user);
        }


        #endregion








        #region Private methods

        private User GetUserByContact(VerificationType type, string contact)
        {
            if (type == VerificationType.Phone)
            {
                return DB.Users.FirstOrDefault(o => o.Phone == contact && !o.IsDeleted);
            }
            else if (type == VerificationType.Email)
            {
                return DB.Users.FirstOrDefault(o => o.Email == contact && !o.IsDeleted);
            }
            return null;
        }
        private User GetUserThrowIfUserNotFound(VerificationType type, string contact)
        {
            User user = GetUserByContact(type, contact);
            if (user == null)
            {
                throw new Exception404("Неверный email или телефон");
            }
            return user;
        }

        #endregion

    }
}
