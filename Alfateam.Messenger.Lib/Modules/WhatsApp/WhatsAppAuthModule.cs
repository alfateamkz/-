using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.WhatsApp
{
    public class WhatsAppAuthModule : AuthModule
    {
        private WhatsAppMessenger Messenger;
        public WhatsAppAuthModule(WhatsAppMessenger messenger)
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
