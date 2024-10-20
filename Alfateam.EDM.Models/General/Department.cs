using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.EDM.Models.General
{
    public class Department : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public List<Department> SubDepartments { get; set; } = new List<Department>();




        public List<Document> Documents { get; set; } = new List<Document>();
        [NotMapped]
        public List<Document> DraftDocuments => Documents.Where(o => o.DraftInfoId != null).ToList();





        /// <summary>
        /// Головное ли подразделение. Если да, то оно не может быть удалено
        /// </summary>
        public bool IsRoot { get; set; }



        /// <summary>
        /// Указывает на субъект документооборота. Ставим всегда, даже в дочерних подразделениях
        /// </summary>
        public int EDMSubjectId { get; set; }


        /// <summary>
        /// Указывает на родительское подразделение, если оно имеется
        /// </summary>
        public int? DepartmentId { get; set; }



        public int? DocumentsAccessId { get; set; }
    }
}
