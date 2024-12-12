using Alfateam.Marketing.Lettering.Lib.Enums;
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

namespace Alfateam.Marketing.Lettering.Lib.Abstractions
{
    public abstract class AbsMailer
    {

        public abstract AuthResponse Auth();
        public abstract AuthResponse Send2FACode(string code);
        public abstract AuthResponse Ping();
        public abstract LogoutResponse Logout();







        public abstract SendMessageResponse Send(string to, MessageCrtUpdDTO model);
        public virtual IEnumerable<SendMessageResponse> SendMany(IEnumerable<string> to, MessageCrtUpdDTO model)
        {
            var responses = new List<SendMessageResponse>();

            foreach(var item in to)
            {
                var response = Send(item, model);
                responses.Add(response);

                if (response.Type == SendMessageResponseType.SMS_InsufficientFunds)
                {
                    break;
                }      
            }

            return responses;
        }



        public abstract IEnumerable<Peer> GetPeers(GetPeersFilter filter);
        public abstract Peer GetPeer(string contact);



        public abstract IEnumerable<Message> GetMessages(GetMessagesFilter filter);
        public abstract Message GetMessage(string id);

    }
}
