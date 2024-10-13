using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes.AfterDocSigning;
using Alfateam.EDM.Models.Documents;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.EDM.Models.General;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{
    /// <summary>
    /// Модель документа
    /// </summary>
    [JsonConverter(typeof(JsonKnownTypesConverter<Document>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DocumentWithFile), "NonFormalizedDocument")]
    [JsonKnownType(typeof(PriceListDocument), "PriceListDocument")]
    [JsonKnownType(typeof(WithPositionItemsDocument), "WithPositionItemsDocument")]
    public class Document : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }



        public DocumentType Type { get; set; }
        public int TypeId { get; set; }


        public DocTypeMetadata DocTypeData { get; set; }


        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }


        public string Title { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }




        public bool IsSigningRequired { get; set; }
        public List<DocumentSigningSide> SigningSides { get; set; } = new List<DocumentSigningSide>();



        /// <summary>
        /// Документы, имеющие отношения к текущему документу. Например, счета на оплату, акты выполненных работ и т.д. 
        /// </summary>
        public List<Document> RelatedDocuments { get; set; } = new List<Document>();





        public DocumentApprovalMetadata Approval { get; set; }
        public DocumentCancellationApprovalMetadata CancellationApproval { get; set; }


        public DocumentSigningMetadata Signing { get; set; }
        public DocumentCancellationMetadata Cancellation { get; set; }





        /// <summary>
        /// Информация о том, был ли просмотрен еще документ или нет
        /// </summary>
        public List<DocumentReadEntry> ReadEntries { get; set; } = new List<DocumentReadEntry>();



        /// <summary>
        /// Автоматическое поле. Указывает на пакет документов, если документ в нем находится
        /// </summary>
        public int? DocumentsParcelId { get; set; }



        /// <summary>
        /// Документ находится в подразделении у каждой стороны документа
        /// У нас хранится в нашем подразделении, у контрагента - в его подразделении и т.д.
        /// </summary>
        public List<Department> DepartmentsReferences { get; set; } = new List<Department>();








        public bool IsOurDocument(int edmSubjectId)
        {        
            return SigningSides.Where(o => o is AlfateamEDMDocumentSigningSide).Cast<AlfateamEDMDocumentSigningSide>().Any(o => o.SubjectId == edmSubjectId);
        }
        public bool IsDocumentReadBy(int edmSubjectId)
        {
            return ReadEntries.Where(o => o is AlfateamEDMDocumentSigningSide).Cast<AlfateamEDMDocumentSigningSide>().Any(o => o.SubjectId == edmSubjectId);
        }


        [NotMapped]
        public bool IsAvailableForSigning => !IsSigned && !IsCancelled && Approval.Status == DocumentApprovalStatus.Approved;

        [NotMapped]
        public bool IsSigned => Signing?.Status == DocumentSigningResultType.Signed
                             || Signing?.Status == DocumentSigningResultType.SignedWithConflict
                             || Signing?.Status == DocumentSigningResultType.DocumentFlowCompleted;
        [NotMapped]
        public bool IsCancelled => Cancellation?.Status == DocumentCancellationResult.Cancelled;
    }
}
