using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdLib;
using static TdLib.TdApi.AuthorizationState;

namespace Alfateam.Messenger.Lib.Modules.Telegram
{
    public class TelegramAuthModule : AuthModule
    {
        private TelegramMessenger Messenger;
        public TelegramAuthModule(TelegramMessenger messenger)
        {
            Messenger = messenger;
        }

        public override async Task<AuthResult> Auth()
        {
            await Messenger.Client.SetAuthenticationPhoneNumberAsync(Messenger.TGAccount.Login);
            var authState = await Messenger.Client.GetAuthorizationStateAsync();

            if (authState is AuthorizationStateWaitPassword waitPassword)
            {
                await Messenger.Client.CheckAuthenticationPasswordAsync(Messenger.TGAccount.Password);
                authState = await Messenger.Client.GetAuthorizationStateAsync();
            }
            else if (authState is AuthorizationStateWaitCode waitCode)
            {
                return AuthResult.TwoFARequired;
            }


            if (authState is AuthorizationStateReady ready)
            {
                return AuthResult.Authorized;
            }
            else
            {
                return AuthResult.InvalidCredentials;
            }
        }
        public override async Task<AuthResult> ConfirmAuth(string code)
        {
            await Messenger.Client.CheckAuthenticationCodeAsync(code);
            var authState = await Messenger.Client.GetAuthorizationStateAsync();

            if (authState is AuthorizationStateReady ready)
            {
                return AuthResult.Authorized;
            }
            else
            {
                return AuthResult.InvalidCredentials;
            }
        }


        public override async Task<string> GetOurUserId()
        {
            var ourUser = await Messenger.Client.GetUserAsync();
            return ourUser.Id.ToString();
        }
    }
}
