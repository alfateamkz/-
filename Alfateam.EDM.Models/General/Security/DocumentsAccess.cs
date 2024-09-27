using Alfateam.Core;
using Alfateam.EDM.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.General.Security
{
    public class DocumentsAccess : AbsModel
    {
        public DocumentsAccessType Type { get; set; } = DocumentsAccessType.AllDepartments;
       
        /// <summary>
        /// Используется, если Type == DocumentsAccessType.OnlySelectedDepartments
        /// </summary>
        public List<Department> SelectedDepartments { get; set; } = new List<Department>();
    }
}
