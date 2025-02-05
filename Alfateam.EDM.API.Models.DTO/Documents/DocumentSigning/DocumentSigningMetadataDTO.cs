using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Enums;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning
{
    public class DocumentSigningMetadataDTO : DTOModelAbs<DocumentSigningMetadata>
    {
        [ForClientOnly]
        public SignatureType SignatureType { get; set; }
        [ForClientOnly]
        public List<DocumentSigningResultDTO> SigningResults { get; set; } = new List<DocumentSigningResultDTO>();

        /// <summary>
        /// Данные роуминга с другим провайдером ЭДО
        /// Используется, если SignatureType == AlfateamEDM и если имеется роуминг с другим провайдером ЭДО
        /// </summary>
        [ForClientOnly]
        public SignedDocumentRoamingInfoDTO? RoamingInfo { get; set; }
    }
}
