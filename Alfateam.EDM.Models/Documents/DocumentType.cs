using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using System.ComponentModel.DataAnnotations.Schema;
using Alfateam.EDM.Models.Enums;
using Alfateam.EDM.Models.Documents.Meta.Structure;

namespace Alfateam.EDM.Models.Documents
{
    public class DocumentType : AbsModel
    {
        public DocumentType()
        {

        }


        public DocumentType(string title, int? minRequiredDocumentSides, DocTypeMetadataStructure metadataStructure)
        {
            Title = title;
            MinRequiredDocumentSides = minRequiredDocumentSides;
            MetadataStructure = metadataStructure;

            IsDefaultType = true;
        }
        public DocumentType(string title, int? minRequiredDocumentSides, DocTypeMetadataStructure metadataStructure, bool isInternal)
        {
            Title = title;
            MinRequiredDocumentSides = minRequiredDocumentSides;
            MetadataStructure = metadataStructure;
            IsInternalDocument = isInternal;

            IsDefaultType = true;
        }
        public DocumentType(string title, int documentSidesCount, DocumentTypePurpose purpose)
        {
            Title = title;
            MinRequiredDocumentSides = documentSidesCount;
            MaxRequiredDocumentSides = documentSidesCount;
            Purpose = purpose;

            MetadataStructure = new DocTypeMetadataStructure();
            IsDefaultType = true;
        }



        public DocumentTypePurpose Purpose { get; set; } = DocumentTypePurpose.ForDocumentWithFile;
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? MinRequiredDocumentSides { get; set; }
        public int? MaxRequiredDocumentSides { get; set; }
        public DocTypeMetadataStructure MetadataStructure { get; set; }




        /// <summary>
        /// Является ли документ для внутреннего пользования. Если да, то нельзя отсылать документ контрагентам
        /// </summary>
        public bool IsInternalDocument { get; set; }


        /// <summary>
        /// Вшит ли тип документа в систему. Если false, то тип кастомный, создан пользователем
        /// </summary>
        public bool IsDefaultType { get; set; }



        /// <summary>
        /// Не равно null - если IsDefaultType == false (кастомный тип документа)
        /// </summary>
        public int? EDMSubjectId { get; set; }
    }
}
