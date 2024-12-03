using Alfateam.Marketing.Models.Abstractions.MailingAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.MailingAccounts
{
    public class EmailMailingAccount : MailingAccount
    {
        public string IMAP3Host { get; set; }
        public int IMAP3Port { get; set; }
    }
}
