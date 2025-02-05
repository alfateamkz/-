using Alfateam.Core.Exceptions;
using Alfateam.Messenger.API.Helpers;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Chats;
using Alfateam.Messenger.Models.Peers;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Alfateam.Messenger.API.Abstractions
{
    public abstract class AbsMessengerController : AbsController
    {
        public AbsMessengerController(ControllerParams @params) : base(@params)
        {
        }


        public int? AccountId => ParseIntValueFromHeader("AccountId");
        public Account? Account => DB.Accounts.FirstOrDefault(o => o.Id == AccountId && !o.IsDeleted && o.CompanyWorkSpaceId == this.WorkspaceID);
        public AbsMessenger? Messenger => AccountsPool.GetOrCreateMessenger(Account);






        public int? ExtMessengerUserId => ParseIntValueFromHeader("ExtMessengerUserId");
        public string? ExtMessengerSecret => Request.Headers["ExtMessengerSecret"];






        protected void ThrowIfNull(object val, string message = "Сущность с данным id не найдена")
        {
            if(val == null)
            {
                throw new Exception404(message);
            }
        }

     



    }
}
