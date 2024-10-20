using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Accounts.SocialNetworks
{
    public class VKAccount : Account
    {
        public string AuthToken { get; set; }
    }
}
