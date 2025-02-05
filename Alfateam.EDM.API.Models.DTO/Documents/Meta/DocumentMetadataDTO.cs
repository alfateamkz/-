using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.Meta;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.Meta
{
    public class DocumentMetadataDTO : DTOModelAbs<DocumentMetadata>
    {
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string? Comment { get; set; }


        public List<DocumentMetadataFieldDTO> Fields { get; set; } = new List<DocumentMetadataFieldDTO>();
    }
}
