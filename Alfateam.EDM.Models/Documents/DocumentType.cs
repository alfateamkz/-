using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.Documents
{
    public class DocumentType : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }





        /// <summary>
        /// Вшит ли тип документа в систему. Если false, то тип кастомный, создан пользователем
        /// </summary>
        public bool IsDefaultType { get; set; }
        public List<DocumentTypeSide> Sides { get; set; } = new List<DocumentTypeSide>();
    }
}
