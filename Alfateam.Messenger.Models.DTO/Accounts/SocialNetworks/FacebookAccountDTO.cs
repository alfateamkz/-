using Alfateam.Messenger.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Accounts.SocialNetworks
{
    public class FacebookAccountDTO : AccountDTO
    {
        public string AuthToken { get; set; }
    }
}
