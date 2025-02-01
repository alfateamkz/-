using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.General;

namespace Alfateam.EDM.API.Models.DTO.Documents.Meta.Fields
{
    public class DocumentMetadataTaxSumInfoFieldDTO : DocumentMetadataFieldDTO
    {
        public TaxSumInfoDTO Value { get; set; }
    }
}
