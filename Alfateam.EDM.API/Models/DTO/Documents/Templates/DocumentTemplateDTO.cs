using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.Models.Documents.Templates;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.Templates
{
    public class DocumentTemplateDTO : DTOModelAbs<DocumentTemplate>
    {
        public string Title { get; set; }

   
        
        [ForClientOnly]
        public DocumentTypeDTO DocumentType { get; set; }

        [HiddenFromClient]
        public int DocumentTypeId { get; set; }




        [ForClientOnly]
        public UploadedFileDTO DocumentFile { get; set; }

        [HiddenFromClient]
        public string DocumentFileId { get; set; }


        public List<DocumentTemplatePlaceholderDTO> Placeholders { get; set; } = new List<DocumentTemplatePlaceholderDTO>();
    }
}
