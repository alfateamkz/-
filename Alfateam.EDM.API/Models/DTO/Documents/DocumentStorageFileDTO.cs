using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents
{
    public class DocumentStorageFileDTO : DTOModelAbs<DocumentStorageFile>
    {
        public string Title { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }

        public DocumentType Type { get; set; }
        public int TypeId { get; set; }



        [ForClientOnly]
        public UploadedFileDTO File { get; set; }

        [HiddenFromClient]
        public string FileId { get; set; }



        public List<DocumentSigningSideDTO> SigningSides { get; set; } = new List<DocumentSigningSideDTO>();
    }
}
