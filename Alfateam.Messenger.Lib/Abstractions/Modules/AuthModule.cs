using Alfateam.Messenger.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Abstractions.Modules
{
    public abstract class AuthModule
    {
        public abstract Task<AuthResult> Auth();
        public abstract Task<AuthResult> ConfirmAuth(string code);

        public abstract Task<string> GetOurUserId();
    }
}
