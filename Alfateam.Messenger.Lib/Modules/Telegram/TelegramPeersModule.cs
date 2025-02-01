using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Models.Abstractions;
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

        public override async Task<Peer> GetPeer(string peerId)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Peer>> GetPeers(int offset, int count, string query = null)
        {
            throw new NotImplementedException();
        }
    }
}
