﻿using Alfateam.Messenger.Lib.Abstractions.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdLib;

namespace Alfateam.Messenger.Lib.Modules.Telegram
{
    public class TelegramPeersModule : PeersModule
    {
        private TelegramMessenger Messenger;
        public TelegramPeersModule(TelegramMessenger messenger)
        {
            Messenger = messenger;
        }


        public override async Task GetPeer(string peerId)
        {

            throw new NotImplementedException();
        }

        public override async Task GetPeers(int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
