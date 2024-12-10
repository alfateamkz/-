using Alfateam.Marketing.Models.Enums;
using Alfateam.Marketing.Models.Templates;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Templates
{
    public class TemplateDTO : DTOModelAbs<Template>
    {
        public string Title { get; set; }
        public ContactType Type { get; set; }
        public string TemplateContent { get; set; }
    }
}
