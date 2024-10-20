using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Lib.Modules.Instagram;
using Alfateam.Messenger.Lib.Modules.WhatsApp;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;
using InstagramApiSharp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib
{
    public class InstagramMessenger : AbsMessenger
    {
        public InstagramAccount InstagramAccount => Account as InstagramAccount;
        public InstagramMessenger(InstagramAccount account) : base(account)
        {
            Auth = new InstagramAuthModule(this);
            Chats = new InstagramChatsModule(this);
            Messages = new InstagramMessagesModule(this);
            Peers = new InstagramPeersModule(this);
            Stickers = new InstagramStickersModule(this);



            //Action();

            //api.MessagingProcessor.SendDirectTextAsync()

            //api.MessagingProcessor.SendDirectTextAsync();
        }

        private async Task Action()
        {
            var api = InstagramApiSharp.API.Builder.InstaApiBuilder.CreateBuilder()
                                                                   .SetUser(new InstagramApiSharp.Classes.UserSessionData
                                                                   {
                                                                       Password = "228228vV_",
                                                                       UserName = "arystan_alfa"
                                                                   })
                                                                   .Build();

            var a = await api.LoginAsync();
            if (a.Value == InstagramApiSharp.Classes.InstaLoginResult.ChallengeRequired)
            {

            }
            else if (a.Value == InstagramApiSharp.Classes.InstaLoginResult.TwoFactorRequired)
            {
                string code = "12345";
                var aaaaRes = api.TwoFactorLoginAsync(code).Result;

            }
            else if (a.Value == InstagramApiSharp.Classes.InstaLoginResult.BadPassword)
            {

            }


            var desireUsername = "kondudaeva.812069";
            var user = await api.UserProcessor.GetUserAsync(desireUsername);
            var userId = user.Value.Pk.ToString();
            var directText = await api.MessagingProcessor
                .SendDirectTextAsync(userId, null, "Сайн уу хонгор минь. Энэ зурвас альфатим мессенжерээр илгээгдсэн байна");
        }
    }
}
