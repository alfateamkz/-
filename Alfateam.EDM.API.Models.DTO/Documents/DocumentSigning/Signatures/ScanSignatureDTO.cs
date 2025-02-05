using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.SharedModels.DTO;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning.Signatures
{
    public class ScanSignatureDTO : SignatureDTO
    {
        [ForClientOnly]
        public UploadedFileDTO File { get; set; }

        [HiddenFromClient]
        public string FileId { get; set; }
    }
}
