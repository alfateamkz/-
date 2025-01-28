using Alfateam.Core.Exceptions;
using Alfateam.Core.Helpers;
using Alfateam.Core.Services;
using Alfateam.DB.Services.Models;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models.Enums;
using Alfateam.ID.Models.Security.Verifications;

namespace Alfateam.DB.Services
{
    public class AlfateamIDCodesService
    {
        public readonly IDDbContext DB;
        public readonly AbsDBService DBService;

        public readonly ISMSGateway SMSGateway;
        public readonly IMailGateway MailGateway;
        public AlfateamIDCodesService(IDDbContext db, 
                                     AbsDBService dbService,

                                     ISMSGateway smsGateway,
                                     IMailGateway mailGateway)
        {
            DB = db;
            DBService.SetDB(DB);

            SMSGateway = smsGateway;
            MailGateway = mailGateway;
        }





        public void SendCode(AlfateamIDSendCodeParams codeParams)
        {
            ThrowIfCodeLimit(codeParams.Type, codeParams.ActionFor, codeParams.Contact);


            var code = PasswordHelper.GeneratePassword(6);
            DBService.CreateEntity(DB.Verifications, new CodeVerification
            {
                SentTo = codeParams.Contact,
                ActionFor = codeParams.ActionFor,
                Type = codeParams.Type,
                Code = code
            });

            if (codeParams.Type == VerificationType.Phone)
            {
                SMSGateway.SendSMS(Gateways.Helpers.StaticCredentials.OFFICIAL_SMS, new Gateways.Models.Messages.SMSMessage
                {
                    PhoneTo = codeParams.Contact,
                    Message = $"{codeParams.MessageText} {code}"
                });
            }
            else if (codeParams.Type == VerificationType.Email)
            {
                MailGateway.SendOfficialMail(new Gateways.Models.Messages.EmailMessage
                {
                    ToDisplayName = codeParams.Contact,
                    Subject = codeParams.LetterTitle,
                    Body = $"{codeParams.MessageText} {code}",
                    ToEmail = codeParams.Contact
                });
            }
        }
        public CodeVerification VerifyCode(VerificationType type, VerificationFor actionFor, string contact, string code)
        {
            var sentCode = DB.Verifications.Where(o => o is CodeVerification 
                                                    && !o.IsVerified 
                                                    && !o.IsExpired 
                                                    && o.ActionFor == actionFor)
                                           .Cast<CodeVerification>()
                                           .FirstOrDefault(o => o.SentTo == contact);
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
            else if (sentCode.IsVerified)
            {
                throw new Exception403($"Код уже использован. Отправьте новый код подтверждения");
            }

            sentCode.IsVerified = true;
            DBService.UpdateEntity(DB.Verifications, sentCode);

            return sentCode;
        }



        protected void ThrowIfCodeLimit(VerificationType type, VerificationFor actionFor, string contact)
        {
            int codeLimit = 10;
            if (type == VerificationType.Phone)
            {
                codeLimit = 3;
            }


            var notVerifiedForDay = DB.Verifications.Where(o => o is CodeVerification
                                                             && !o.IsVerified
                                                             && o.CreatedAt >= DateTime.UtcNow.AddHours(-12)
                                                             && o.ActionFor == actionFor)
                                                    .Cast<CodeVerification>()
                                                    .Where(o => o.SentTo == contact && o.Type == type)
                                                    .ToList();


            var notVerifiedExpiredForDay = notVerifiedForDay.Where(o => o.IsExpired).ToList();
            if (notVerifiedExpiredForDay.Count > 0)
            {
                var lastExpiredNotVerified = notVerifiedExpiredForDay.LastOrDefault();
                var hasVerifiedAfterExpired = DB.Verifications.Where(o => o is CodeVerification
                                                                       && o.IsVerified
                                                                       && o.CreatedAt >= lastExpiredNotVerified.CreatedAt
                                                                       && o.ActionFor == actionFor)
                                                              .Cast<CodeVerification>()
                                                              .Any(o => o.SentTo == contact && o.Type == type);

                if (notVerifiedExpiredForDay.Count >= codeLimit && !hasVerifiedAfterExpired)
                {
                    throw new Exception403("Превышен лимит отправки кодов. Попробуйте отправить код повторно через 12 часов");
                }
            }

            var notVerifiedNotExpired = notVerifiedForDay.Where(o => !o.IsExpired).LastOrDefault();
            if (notVerifiedNotExpired != null && notVerifiedNotExpired.CreatedAt.AddMinutes(2) > DateTime.UtcNow)
            {
                throw new Exception403("Подождите. Код должен с секунды на секунду прийти");
            }
        }
    }
}
