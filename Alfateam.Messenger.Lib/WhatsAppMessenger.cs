using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Lib.Modules.Telegram;
using Alfateam.Messenger.Lib.Modules.WhatsApp;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts.Messengers;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib
{
    public class WhatsAppMessenger : AbsMessenger
    {
        public WhatsAppAccount WhatsAppAccount => Account as WhatsAppAccount;
        public WhatsAppMessenger(WhatsAppAccount account) : base(account)
        {
            Auth = new WhatsAppAuthModule(this);
            Chats = new WhatsAppChatsModule(this);
            Messages = new WhatsAppMessagesModule(this);
            Peers = new WhatsAppPeersModule(this);
            Stickers = new WhatsAppStickersModule(this);

            var client = new WhatsappBusiness.CloudApi.WhatsAppBusinessClient(new WhatsappBusiness.CloudApi.Configurations.WhatsAppBusinessCloudApiConfig
            {

            });

         

            //var res = client.CreateTemplateMessage();
            //res.S


            //client.VerifyCode(new WhatsappBusiness.CloudApi.PhoneNumbers.Requests.VerifyCodeRequest
            //{
            //    Code = "12433"
            //});

            //client.SendTextMessage(new WhatsappBusiness.CloudApi.Messages.Requests.TextMessageRequest
            //{
            //    To = "77058832744",
            //    Text = new WhatsappBusiness.CloudApi.Messages.Requests.WhatsAppText
            //    {
            //        Body = "dsf",
            //        PreviewUrl = false
            //    }
            //});
        }
    }
}
