﻿using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Lib.Models;
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
                return AuthResult.Create(AuthResultType.TwoFARequired);
            }


            if (authState is AuthorizationStateReady ready)
            {
                return AuthResult.Create(AuthResultType.Authorized);
            }
            else
            {
                return AuthResult.Create(AuthResultType.InvalidCredentials);
            }
        }
        public override async Task<AuthResult> ConfirmAuth(string code)
        {
            await Messenger.Client.CheckAuthenticationCodeAsync(code);
            var authState = await Messenger.Client.GetAuthorizationStateAsync();

            if (authState is AuthorizationStateReady ready)
            {
                return AuthResult.Create(AuthResultType.Authorized);
            }
            else
            {
                return AuthResult.Create(AuthResultType.InvalidCredentials);
            }
        }

        public override Task<Request2FACodeResult> Request2FACode()
        {
            throw new NotImplementedException();
        }


        public override async Task<string> GetOurUserId()
        {
            var ourUser = await Messenger.Client.GetUserAsync();
            return ourUser.Id.ToString();
        }

        public override async Task<UserInfo> GetOurUserInfo()
        {
            throw new NotImplementedException();
        }
    }
}
