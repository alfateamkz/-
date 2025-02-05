using Alfateam.EDM.Models.Documents.Meta.Structure;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.Meta.Structure
{
    public class DocTypeMetadataStructureDTO : DTOModelAbs<DocTypeMetadataStructure>
    {
        public List<DocTypeMetadataStructureFieldDTO> Fields { get; set; } = new List<DocTypeMetadataStructureFieldDTO>();
    }
}
