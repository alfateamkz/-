using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Documents.DocumentSigning;
using Alfateam.EDM.API.Models.DTO.Documents.Types;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.Website.API.Abstractions;
using JsonKnownTypes;
using Newtonsoft.Json;

namespace Alfateam.EDM.API.Models.DTO.Abstractions
{
    [JsonConverter(typeof(JsonKnownTypesConverter<DocumentDTO>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DocumentWithFileDTO), "NonFormalizedDocument")]
    [JsonKnownType(typeof(PriceListDocumentDTO), "PriceListDocument")]
    [JsonKnownType(typeof(WithPositionItemsDocumentDTO), "WithPositionItemsDocument")]
    public class DocumentDTO : DTOModelAbs<Document>
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        [ForClientOnly]
        public UserDTO CreatedBy { get; set; }
        [ForClientOnly]
        public int CreatedById { get; set; }


        public string Title { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }


        public bool IsSigningRequired { get; set; }
        public List<DocumentSigningSideDTO> SigningSides { get; set; } = new List<DocumentSigningSideDTO>();

        /// <summary>
        /// Документы, имеющие отношения к текущему документу. Например, счета на оплату, акты выполненных работ и т.д. 
        /// </summary>
        [ForClientOnly]
        public List<DocumentDTO> RelatedDocuments { get; set; } = new List<DocumentDTO>();


 


        [ForClientOnly]
        public DocumentApprovalMetadataDTO Approval { get; set; }

        [ForClientOnly]
        public DocumentSigningMetadataDTO Signing { get; set; }
        [ForClientOnly]
        public DocumentSigningMetadataDTO? Cancellation { get; set; }







        [ForClientOnly]
        public int? DocumentsParcelId { get; set; }
    }
}
