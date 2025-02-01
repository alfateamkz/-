using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Abstractions.Modules
{
    public abstract class PeersModule
    {
        public abstract Task<IEnumerable<Peer>> GetPeers(int offset, int count, string query = null);
        public abstract Task<Peer> GetPeer(string peerId);
    }
}
