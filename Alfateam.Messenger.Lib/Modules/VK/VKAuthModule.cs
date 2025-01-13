using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet;
using Alfateam.Messenger.Lib.Models;

namespace Alfateam.Messenger.Lib.Modules.VK
{
    public class VKAuthModule : AuthModule
    {
        private VkMessenger Messenger;
        public VKAuthModule(VkMessenger messenger)
        {
            Messenger = messenger;
        }
        public override async Task<AuthResult> Auth()
        {
            Messenger.VkApi.Authorize(new ApiAuthParams
            {
                Password = Messenger.VKAccount.Password,
                Login = Messenger.VKAccount.Login,
                ApplicationId = VkMessenger.ApplicationID,
                AccessToken = Messenger.VKAccount.AuthToken
            });

            if (Messenger.VkApi.IsAuthorized)
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
            throw new NotImplementedException();
        }

        public override Task<Request2FACodeResult> Request2FACode()
        {
            throw new NotImplementedException();
        }

        public override Task<string> GetOurUserId()
        {
            throw new NotImplementedException();
        }

        public override async Task<UserInfo> GetOurUserInfo()
        {
            throw new NotImplementedException();
        }
    }
}
