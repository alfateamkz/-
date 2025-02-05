using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Results
{
    public class DocumentSuccessfullySignedResultDTO : DocumentSigningResultDTO
    {
        public SignatureDTO Signature { get; set; }
    }
}
