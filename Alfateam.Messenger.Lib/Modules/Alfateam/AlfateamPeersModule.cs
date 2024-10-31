using Alfateam.Messenger.Lib.Abstractions.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Alfateam
{
    public class AlfateamPeersModule : PeersModule
    {
        private AlfateamMessenger Messenger;
        public AlfateamPeersModule(AlfateamMessenger messenger)
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
