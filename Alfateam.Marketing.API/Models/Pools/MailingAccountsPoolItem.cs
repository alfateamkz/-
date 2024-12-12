using Alfateam.Marketing.Autoposting.Lib.Abstractions;
using Alfateam.Marketing.Lettering.Lib.Abstractions;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Abstractions.MailingAccounts;

namespace Alfateam.Marketing.API.Models.Pools
{
    public class MailingAccountsPoolItem
    {
        public MailingAccount Account { get; set; }
        public AbsMailer Mailer { get; set; }
    }
}
