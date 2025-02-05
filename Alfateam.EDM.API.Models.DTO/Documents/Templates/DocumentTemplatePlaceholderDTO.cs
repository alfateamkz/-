using Alfateam.EDM.Models.Documents.Templates;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.Templates
{
    public class DocumentTemplatePlaceholderDTO : DTOModelAbs<DocumentTemplatePlaceholder>
    {
        public string Title { get; set; }
        public string Placeholder { get; set; }
        public bool IsRequired { get; set; }
    }
}
