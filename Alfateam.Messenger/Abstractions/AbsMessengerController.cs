using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Alfateam.Messenger.API.Abstractions
{
    public abstract class AbsMessengerController : AbsController
    {
        protected AbsMessengerController(ControllerParams @params) : base(@params)
        {
        }


        public int? AccountId
        {
            get
            {
                if (int.TryParse(Request.Headers["AccountId"], out _))
                {
                    return Convert.ToInt32(Request.Headers["AccountId"]);
                }
                return null;
            }
        }
        public Account? Account => DB.Accounts.FirstOrDefault(o => o.Id == AccountId);
    }
}
