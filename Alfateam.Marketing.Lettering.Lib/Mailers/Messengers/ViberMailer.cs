using Alfateam.Marketing.Lettering.Lib.Abstractions;
using Alfateam.Marketing.Lettering.Lib.Models;
using Alfateam.Marketing.Lettering.Lib.Models.CrtUpdDTO;
using Alfateam.Marketing.Lettering.Lib.Models.Filters;
using Alfateam.Marketing.Lettering.Lib.Models.Messages;
using Alfateam.Marketing.Lettering.Lib.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Lettering.Lib.Mailers.Messengers
{
    public class ViberMailer : AbsMailer
    {
        public override AuthResponse Auth()
        {
            throw new NotImplementedException();
        }

        public override Message GetMessage(string id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Message> GetMessages(GetMessagesFilter filter)
        {
            throw new NotImplementedException();
        }

        public override Peer GetPeer(string contact)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Peer> GetPeers(GetPeersFilter filter)
        {
            throw new NotImplementedException();
        }

        public override LogoutResponse Logout()
        {
            throw new NotImplementedException();
        }

        public override AuthResponse Ping()
        {
            throw new NotImplementedException();
        }

        public override SendMessageResponse Send(string to, MessageCrtUpdDTO model)
        {
            throw new NotImplementedException();
        }

        public override AuthResponse Send2FACode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
