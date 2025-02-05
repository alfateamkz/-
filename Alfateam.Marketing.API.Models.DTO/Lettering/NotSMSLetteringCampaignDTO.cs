using Alfateam.Core.Attributes.DTO;
using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.Marketing.API.Models.DTO.Abstractions.MailingAccounts;
using Alfateam.Marketing.Models.Abstractions.MailingAccounts;

namespace Alfateam.Marketing.API.Models.DTO.Lettering
{
    public class NotSMSLetteringCampaignDTO : LetteringCampaignDTO
    {
        [ForClientOnly]
        public MailingAccountDTO Account { get; set; }

        [HiddenFromClient]
        public int AccountId { get; set; }
    }
}
