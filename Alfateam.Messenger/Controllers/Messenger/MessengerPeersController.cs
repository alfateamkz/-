using Alfateam.Messenger.API.Abstractions;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.DTO.Abstractions;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static TdLib.TdApi;

namespace Alfateam.Messenger.API.Controllers.Messenger
{
    public class MessengerPeersController : AbsMessengerController
    {
        public MessengerPeersController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("GetPeers")]
        public async Task<IEnumerable<PeerDTO>> GetPeers(int offset, int count = 20, string query = null)
        {
            IEnumerable<Peer> peers = null; 
            if (Account != null)
            {
                peers = await Messenger.Peers.GetPeers(offset, count, query);
            }
            else if (false)
            {

            }
            else
            {
               
            }

            return new PeerDTO().CreateDTOs(peers).Cast<PeerDTO>();
        }

        [HttpGet, Route("GetPeer")]
        public async Task<PeerDTO> GetPeer(string peerId)
        {
            Peer peer = null;
            if (Account != null)
            {
                peer = await Messenger.Peers.GetPeer(peerId);
            }
            else if (false)
            {

            }
            else
            {

            }

            ThrowIfNull(peer);
            return (PeerDTO)new PeerDTO().CreateDTO(peer);
        }
    }
}
