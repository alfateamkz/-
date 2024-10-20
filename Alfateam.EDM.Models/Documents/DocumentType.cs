using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using System.ComponentModel.DataAnnotations.Schema;
using Alfateam.EDM.Models.Enums;

namespace Alfateam.EDM.Models.Documents
{
    public class DocumentType : AbsModel
    {
        public DocumentType()
        {

        }
        public DocumentType(string title, int? minRequiredDocumentSides, DocumentTypeEnum type)
        {
            Title = title;
            MinRequiredDocumentSides = minRequiredDocumentSides;
            Type = type;

            IsDefaultType = true;
        }
        public DocumentType(string title, int? minRequiredDocumentSides, DocumentTypeEnum type, bool isInternal)
        {
            Title = title;
            MinRequiredDocumentSides = minRequiredDocumentSides;
            Type = type;
            IsInternalDocument = isInternal;

            IsDefaultType = true;
        }



        public string Title { get; set; }
        public string? Description { get; set; }
        public int? MinRequiredDocumentSides { get; set; }
        public int? MaxRequiredDocumentSides { get; set; }


        public DocumentTypeEnum Type { get; set; } = DocumentTypeEnum.NonFormalized;



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
