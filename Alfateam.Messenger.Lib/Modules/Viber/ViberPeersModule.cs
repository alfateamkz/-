using Alfateam.Messenger.Lib.Abstractions.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Viber
{
    public class ViberPeersModule : PeersModule
    {
        private ViberMessenger Messenger;
        public ViberPeersModule(ViberMessenger messenger)
        {
            Messenger = messenger;
        }



        public override Task GetPeer(string peerId)
        {
            throw new NotImplementedException();
        }

        public override Task GetPeers(int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
