using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.Documents
{
    public class CreateDocumentResult
    {
        public bool Success => CreatedDocument != null;
        public DocumentDTO? CreatedDocument { get; set; }
        public string? Error { get; set; }
    }
}
