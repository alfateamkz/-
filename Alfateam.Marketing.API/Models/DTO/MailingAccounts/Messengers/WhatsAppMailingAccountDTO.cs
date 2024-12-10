using Alfateam.Marketing.API.Models.DTO.Abstractions.MailingAccounts;

namespace Alfateam.Marketing.API.Models.DTO.MailingAccounts.Messengers
{
    public class WhatsAppMailingAccountDTO : MessengerMailingAccountDTO
    {
        public string AuthToken { get; set; }
    }
}
