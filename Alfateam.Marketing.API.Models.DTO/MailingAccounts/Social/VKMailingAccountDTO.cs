using Alfateam.Marketing.API.Models.DTO.Abstractions.MailingAccounts;

namespace Alfateam.Marketing.API.Models.DTO.MailingAccounts.Social
{
    public class VKMailingAccountDTO : SocialMailingAccountDTO
    {
        public string AuthToken { get; set; }
    }
}
