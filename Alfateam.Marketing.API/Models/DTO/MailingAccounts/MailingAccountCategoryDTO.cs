using Alfateam.Marketing.Models.MailingAccounts;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.MailingAccounts
{
    public class MailingAccountCategoryDTO : DTOModelAbs<MailingAccountCategory>
    {
        public string Title { get; set; }
    }
}
