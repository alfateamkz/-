using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.Documents.Meta;
using Alfateam.EDM.Models.Documents.Meta;
using Alfateam.SharedModels.DTO;

namespace Alfateam.EDM.API.Models.DTO.Documents.Types
{
    public class DocumentWithFileDTO : DocumentDTO
    {
        [HiddenFromClient]
        public int TypeId { get; set; }


        [ForClientOnly]
        public UploadedFileDTO File { get; set; }

        [HiddenFromClient, DTOFieldFor(DTOFieldForType.CreationOnly)]
        public string FileId { get; set; }
    }
}
