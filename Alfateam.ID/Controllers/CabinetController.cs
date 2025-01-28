using Alfateam.Core.Exceptions;
using Alfateam.Core.Helpers;
using Alfateam.ID.Abstractions;
using Alfateam.ID.API.Filters;
using Alfateam.ID.API.Models;
using Alfateam.ID.Models.DTO;
using Alfateam.ID.Models;
using Alfateam.ID.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Alfateam.DB.Services.Models;

namespace Alfateam.ID.API.Controllers
{
    [AuthorizedUser(mustBeVerified: true)]
    public class CabinetController : AbsController
    {
        public CabinetController(ControllerParams @params) : base(@params)
        {
        }

        [HttpPut, Route("UpdateUser")]
        public async Task UpdateUser(UserUpdateDataDTO model)
        {
            DBService.TryUpdateEntity(DB.Users, model, this.Session.User);
        }

        [HttpPut, Route("SetUserLang")]
        public async Task SetUserLang(string langCode)
        {
            var user = this.Session.User;
            user.LanguageCode = langCode;
            DBService.UpdateEntity(DB.Users, user);
        }


        #region Смена пароля и контактных данных (email и телефон)

        [HttpPut, Route("ChangePassword")]
        public async Task ChangePassword(string oldPassword, string newPassword)
        {
            var user = this.Session.User;
            if(!PasswordHelper.CheckEncryptedPassword(oldPassword, user.Password))
            {
                throw new Exception403("Старый пароль не совпадает с установленным паролем");
            }
            else if (newPassword?.Length < 8)
            {
                throw new Exception403("Длина пароля должна составлять 8 или более символов");
            }

            user.Password = PasswordHelper.EncryptPassword(newPassword);
            DBService.UpdateEntity(DB.Users, user);
        }






        [HttpPut, Route("SendChangeContactCode")]
        public async Task SendChangeContactCode(VerificationType type)
        {
            CodesService.SendCode(new AlfateamIDSendCodeParams
            {
                Type = type,
                Contact = this.Session.User.GetContact(type),
                ActionFor = VerificationFor.ContactChangeVerification,
                LetterTitle = "Изменение контакта в Alfateam ID",
                MessageText = "Код для изменения контакта в Alfateam ID:",
            });
        }

        [HttpPut, Route("VerifyChangeContact")]
        public async Task VerifyChangeContact(VerificationType type, string code, string newContact)
        {
            var user = this.Session.User;


            CodesService.VerifyCode(type, VerificationFor.ContactChangeVerification, user.GetContact(type), code);
            if (type == VerificationType.Phone)
            {
                user.Phone = newContact;
            }
            else if (type == VerificationType.Email)
            {
                user.Email = newContact;
            }

            DBService.UpdateEntity(DB.Users, user);
        }

        #endregion
    }
}
