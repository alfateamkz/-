using Alfateam.EDM.API.Models.DTO.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.Meta.Fields
{
    public class DocumentMetadataDateFieldDTO : DocumentMetadataFieldDTO
    {
        public DateTime Value { get; set; }
    }
}
