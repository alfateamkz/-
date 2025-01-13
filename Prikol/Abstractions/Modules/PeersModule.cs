using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Abstractions.Modules
{
    public abstract class PeersModule
    {
        public abstract Task GetPeers(int offset, int count);
        public abstract Task GetPeer(string peerId);
    }
}
