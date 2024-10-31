using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Alfateam
{
    public class AlfateamAuthModule : AuthModule
    {
        private AlfateamMessenger Messenger;
        public AlfateamAuthModule(AlfateamMessenger messenger)
        {
            Messenger = messenger;
        }
        public override async Task<AuthResult> Auth()
        {
            throw new NotImplementedException();
        }

        public override async Task<AuthResult> ConfirmAuth(string code)
        {
            throw new NotImplementedException();
        }

        public override async Task<string> GetOurUserId()
        {
            throw new NotImplementedException();
        }
    }
}
