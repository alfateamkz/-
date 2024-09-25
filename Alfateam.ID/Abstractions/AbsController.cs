using Alfateam.Core.Exceptions;
using Alfateam.Core.Filters;
using Alfateam.Core.Helpers;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models;
using Alfateam.ID.Models.Enums;
using Alfateam.ID.Models.Security;
using Alfateam.ID.Models.Security.Verifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.ID.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [ErrorsFilter]
    [APIExceptionFilter]
    public abstract class AbsController : ControllerBase
    {
        public readonly IDDbContext DB;
        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;
        public AbsController(ControllerParams @params)
        {
            this.DB = @params.DB;
            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway; 
            this.SMSGateway = @params.SMSGateway;   
        }


        public virtual Session? Session => DB.Sessions.Include(o => o.User)
                                                      .FirstOrDefault(o => o.SessID == this.UserSessid);
        public string UserSessid => Request.Headers["Sessid"];


        protected Session CreateSession(User user)
        {
            var session = new Session()
            {
                UserId = user.Id,
            };

            DBService.CreateEntity(DB.Sessions, session);
            return session;
        }



        protected void SendCode(VerificationType type, string contact, string letterTitle, string messageText)
        {
            var code = PasswordHelper.GeneratePassword(6);

            DBService.CreateEntity(DB.Verifications, new CodeVerification
            {
                SentTo = contact,
                Type = type,
                Code = code
            });

            if (type == VerificationType.Phone)
            {
                SMSGateway.SendSMS(Gateways.Helpers.StaticCredentials.OFFICIAL_SMS, new Gateways.Models.Messages.SMSMessage
                {
                    PhoneTo = contact,
                    Message = $"{messageText} {code}"
                });
            }
            else if (type == VerificationType.Email)
            {
                MailGateway.SendOfficialMail(new Gateways.Models.Messages.EmailMessage
                {
                    ToDisplayName = contact,
                    Subject = letterTitle,
                    Body = $"{messageText} {code}",
                    ToEmail = contact
                });
            }
        }
        protected void VerifyCode(VerificationType type, string contact, string code)
        {
            var sentCode = DB.Verifications.Where(o => o is CodeVerification && !o.IsVerified && !o.IsExpired)
                                         .AsEnumerable()
                                         .FirstOrDefault(o => o is CodeVerification code && code.SentTo == contact) as CodeVerification;
            if (sentCode == null)
            {
                throw new Exception400($"Запросите сначала код на контакт {contact}");
            }
            else if (sentCode.Code != code)
            {
                throw new Exception403($"Код не совпадает с отправленным на контакт {contact}");
            }
            else if (sentCode.IsExpired)
            {
                throw new Exception403($"Срок действия кода закончился. Отправьте новый код подтверждения");
            }

            sentCode.IsVerified = true;
            DBService.UpdateEntity(DB.Verifications, sentCode);
        }
    }
}
