using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.Documents.Types;
using Alfateam.EDM.Models.General;
using JsonKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.DocumentSigning.ApproveStrategies
{

    public class DocumentApprovalDepartmentStrategy : DocumentApproveStrategy
    {
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        /// <summary>
        /// Если список пустой, то могут согласовывать документы все сотрудники подразделения
        /// </summary>
        public List<User> AllowedUsers { get; set; } = new List<User>();
    }
}
