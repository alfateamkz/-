using Alfateam.EDM.Models.Documents.Meta.Structure;
using Alfateam.EDM.Models.Enums;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.Meta.Structure
{
    public class DocTypeMetadataStructureFieldDTO : DTOModelAbs<DocTypeMetadataStructureField>
    {
        public string Title { get; set; }
        public string JSONName { get; set; }
        public DocTypeMetadataStructureFieldType FieldType { get; set; }
        public bool IsRequired { get; set; }



        public bool DisplayToEDMDocsList { get; set; }
    }
}
