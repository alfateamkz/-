using Alfateam.Marketing.API.Models.DTO.Abstractions.MailingAccounts;

namespace Alfateam.Marketing.API.Models.DTO.MailingAccounts.Messengers
{
    public class TelegramMailingAccountDTO : MessengerMailingAccountDTO
    {
        public string AuthToken { get; set; }
    }
}
