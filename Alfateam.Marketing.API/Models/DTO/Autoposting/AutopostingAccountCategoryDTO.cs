using Alfateam.Marketing.Models.Autoposting;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Autoposting
{
    public class AutopostingAccountCategoryDTO : DTOModelAbs<AutopostingAccountCategory>
    {
        public string Title { get; set; }
    }
}
