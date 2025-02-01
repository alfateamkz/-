using Alfateam.Core;
using Alfateam.EDM.Models.Abstractions.ApprovalRoutes;
using Alfateam.EDM.Models.ApprovalRoutes.AfterDocSigning;
using Alfateam.EDM.Models.Documents;
using Alfateam.EDM.Models.Documents.DocumentSigning;
using Alfateam.EDM.Models.Documents.DocumentSigning.Sides;
using Alfateam.EDM.Models.Documents.Formats;
using Alfateam.EDM.Models.Documents.Meta;
using Alfateam.EDM.Models.Documents.Meta.Fields;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Enums.DocumentStatuses;
using Alfateam.EDM.Models.General;
using JsonKnownTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{
    /// <summary>
    /// Модель документа
    /// </summary>
    [JsonConverter(typeof(JsonKnownTypesConverter<Document>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(DocumentsParcel), "DocumentsParcel")]
    [JsonKnownType(typeof(DocumentWithFile), "NonFormalizedDocument")]
    [JsonKnownType(typeof(PriceListDocument), "PriceListDocument")]
    [JsonKnownType(typeof(WithPositionItemsDocument), "WithPositionItemsDocument")]
    public class Document : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public DocumentType Type { get; set; }
        public int TypeId { get; set; }


        public DocumentMetadata Metadata { get; set; }


        /// <summary>
        /// Если DraftInfo != null, то документ - черновик
        /// </summary>
        public DocumentDraftInfo? DraftInfo { get; set; }
        public int? DraftInfoId { get; set; }



        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }


        public string Title { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }




        public DateTime? DeliveredToSigningSidesAt { get; set; }
        public DateTime? TariffedAt { get; set; }
        public DateTime? StatusChangedAt { get; set; }



        public bool IsSigningRequired { get; set; }
        public List<AlfateamEDMDocumentSigningSide> SigningSides { get; set; } = new List<AlfateamEDMDocumentSigningSide>();



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
        public bool IsAvailableForApproval => !IsSigned && !IsCancelled && Approval.Status == DocumentApprovalStatus.OnApprovalOrSigningStage;
        [NotMapped]
        public bool IsAvailableForSigning => !IsSigned && !IsCancelled && Approval.Status == DocumentApprovalStatus.Approved;
        [NotMapped]
        public bool IsAvailableForCancellation => IsSigned && !IsCancelled 
                                                    && CancellationApproval.Status == DocumentCancellationApprovalStatus.CancellationApproved
                                                    && Cancellation.Status == DocumentCancellationResult.CancellationRequested;


        [NotMapped]
        public bool IsSigned => Signing?.Status == DocumentSigningResultType.Signed
                             || Signing?.Status == DocumentSigningResultType.SignedWithConflict
                             || Signing?.Status == DocumentSigningResultType.DocumentFlowCompleted;
        [NotMapped]
        public bool IsCancelled => Cancellation.Status == DocumentCancellationResult.Cancelled;






        public void Init(int createdById)
        {
            this.CreatedById = createdById;
            this.Approval = new DocumentApprovalMetadata();
            this.Signing = new DocumentSigningMetadata();
            this.Cancellation = new DocumentCancellationMetadata();
            this.CancellationApproval = new DocumentCancellationApprovalMetadata();
        }





        public bool IsValidDocumentTypeMetadata()
        {
            foreach (var structureField in Type.MetadataStructure.Fields)
            {
                var docMetadataField = Metadata.Fields.FirstOrDefault(o => o.FieldName == structureField.JSONName);
                if (docMetadataField == null && structureField.IsRequired)
                {
                    return false;
                }
                else if (docMetadataField != null)
                {
                    if (!AreSameType(docMetadataField, structureField.FieldType))
                    {
                        return false;
                    }

                    if (structureField.IsRequired)
                    {
                        if (docMetadataField is DocumentMetadataStringField stringField && string.IsNullOrEmpty(stringField.Value))
                        {
                            return false;
                        }
                        else if (docMetadataField is DocumentMetadataCurrencyCodeField currencyCodeField && string.IsNullOrEmpty(currencyCodeField.Value))
                        {
                            return false;
                        }
                        else if (docMetadataField is DocumentMetadataTaxSumInfoField taxSumInfoField && taxSumInfoField.Value == null)
                        {
                            return false;
                        }
                    }



                }
            }
            return true;
        }
        private bool AreSameType(DocumentMetadataField field, DocTypeMetadataStructureFieldType type)
        {
            switch (type)
            {
                case DocTypeMetadataStructureFieldType.String:
                    return field is DocumentMetadataStringField;
                case DocTypeMetadataStructureFieldType.CurrencyCode:
                    return field is DocumentMetadataCurrencyCodeField;
                case DocTypeMetadataStructureFieldType.Double:
                    return field is DocumentMetadataDoubleField;
                case DocTypeMetadataStructureFieldType.Date:
                    return field is DocumentMetadataDateField;
                case DocTypeMetadataStructureFieldType.Integer:
                    return field is DocumentMetadataIntegerField;
                case DocTypeMetadataStructureFieldType.TaxSumInfo:
                    return field is DocumentMetadataTaxSumInfoField;
            }
            throw new NotImplementedException("AreSameType type not implemented");
        }
    }
}
