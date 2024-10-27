using Alfateam.Messenger.Models.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.Accounts
{
    public class EmailAccountDTO : AccountDTO
    {
        public string IMAP3Host { get; set; }
        public int IMAP3Port { get; set; }
    }
}
