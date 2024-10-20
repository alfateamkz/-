using Alfateam.Messenger.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.Accounts
{
    public class EmailAccount : Account
    {
        public string IMAP3Host{ get; set; }
        public int IMAP3Port { get; set; }
    }
}
