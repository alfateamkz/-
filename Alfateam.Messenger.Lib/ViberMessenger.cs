using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib
{
    public class ViberMessenger : AbsMessenger
    {
        public ViberAccount ViberAccount => Account as ViberAccount;
        public ViberMessenger(ViberAccount account) : base(account)
        {
           
        }
    }
}
