using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Lib.Modules.Telegram;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts.Messengers;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;
using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdLib;
using static TdLib.TdApi.AuthorizationState;
using static TdLib.TdApi.InputFile;
using static TdLib.TdApi.InputMessageContent;

namespace Alfateam.Messenger.Lib
{
    public class TGClient : TdApi.Client
    {
        public override TResult Execute<TResult>(TdApi.Function<TResult> function)
        {
            throw new NotImplementedException();
        }

        public override Task<TResult> ExecuteAsync<TResult>(TdApi.Function<TResult> function)
        {
            throw new NotImplementedException();
        }

        public override void Send<TResut>(TdApi.Function<TResut> function)
        {
            throw new NotImplementedException();
        }
    }

    public class TelegramMessenger : AbsMessenger
    {
        protected const int API_ID = 1;
        protected const string API_HASH = "";

        internal TdApi.Client Client;
        internal TelegramAccount TGAccount => Account as TelegramAccount;


        public TelegramMessenger(TelegramAccount account) : base(account)
        {
            Client = new TGClient();

            Auth = new TelegramAuthModule(this);
            Chats = new TelegramChatsModule(this);
            Messages = new TelegramMessagesModule(this);
            Peers = new TelegramPeersModule(this);
            Stickers = new TelegramStickersModule(this);
        }
        ~TelegramMessenger()
        {
            Client = null;
        }


    }
}
