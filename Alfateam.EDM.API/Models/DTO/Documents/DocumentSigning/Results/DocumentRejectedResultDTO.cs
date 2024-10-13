using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Results
{
    public class DocumentRejectedResultDTO : DocumentSigningResultDTO
    {
        public string? Comment { get; set; }
    }
}
