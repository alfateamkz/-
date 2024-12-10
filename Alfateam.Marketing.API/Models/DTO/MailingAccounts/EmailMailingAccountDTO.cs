using Alfateam.Marketing.API.Models.DTO.Abstractions.MailingAccounts;

namespace Alfateam.Marketing.API.Models.DTO.MailingAccounts
{
    public class EmailMailingAccountDTO : MailingAccountDTO
    {
        public string IMAP3Host { get; set; }
        public int IMAP3Port { get; set; }
    }
}
