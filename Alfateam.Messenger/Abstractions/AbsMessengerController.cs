using Alfateam.Messenger.API.Helpers;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Models.Abstractions;
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
        public MessengerMailingAccount? Account => DB.Accounts.FirstOrDefault(o => o.Id == AccountId);
        public AbsMessenger? Messenger => AccountsPool.GetOrCreateMessenger(Account);
    }
}
