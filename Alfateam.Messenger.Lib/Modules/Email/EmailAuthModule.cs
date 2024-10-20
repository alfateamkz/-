using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Email
{
    public class EmailAuthModule : AuthModule
    {
        private EmailMessenger Messenger;
        public EmailAuthModule(EmailMessenger messenger)
        {
            Messenger = messenger;
        }
        public override async Task<AuthResult> Auth()
        {
            if (!Messenger.Imap.IsConnected)
            {
                await Messenger.Imap.ConnectAsync(Messenger.EmailAccount.IMAP3Host, Messenger.EmailAccount.IMAP3Port, true);
                if (!Messenger.Imap.IsConnected)
                {
                    return AuthResult.InvalidCredentials;
                }
            }

            if (!Messenger.Imap.IsAuthenticated)
            {
                await Messenger.Imap.AuthenticateAsync(Messenger.EmailAccount.Login, Messenger.EmailAccount.Password);
                if (!Messenger.Imap.IsAuthenticated)
                {
                    return AuthResult.InvalidCredentials;
                }
            }

            return AuthResult.Authorized;
        }

        public override async Task<AuthResult> ConfirmAuth(string code)
        {
            throw new NotSupportedException("Верификация через код недоступна для электронных почт");
        }

        public override async Task<string> GetOurUserId()
        {
            return Messenger.EmailAccount.Login;
        }
    }
}
