using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Accountance.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Departments
{
    /// <summary>
    /// Отдел бухгалтерии 
    /// </summary>
    public class AccountanceDepartment : Department
    {
        public List<LoanObligation> LoanObligations { get; set; } = new List<LoanObligation>();
    }
}
