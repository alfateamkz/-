using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.Types
{
    public sealed class DocumentsParcelDTO : DocumentDTO
    {
        public List<DocumentDTO> Documents { get; set; } = new List<DocumentDTO>();
    }
}
