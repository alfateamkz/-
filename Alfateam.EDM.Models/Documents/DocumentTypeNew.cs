using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents
{
    public class DocumentTypeNew : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


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
