using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;
using Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Departments
{
    /// <summary>
    /// Юридический отдел
    /// </summary>
    public class LawDepartment : Department
    {

        #region Documents
        public List<Document> Documents { get; set; } = new List<Document>();
        #endregion

        #region LegalCases
        public List<LegalCase> LegalCases { get; set; } = new List<LegalCase>();

        #endregion

        public List<LawyerTask> LawyerTasks { get; set; } = new List<LawyerTask>();

        
    }
}
