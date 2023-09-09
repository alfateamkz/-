using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.LegalCases
{
    /// <summary>
    /// Результат юридического дела
    /// </summary>
    public class LegalCaseResult : AbsModel
    {
        public string Decision { get; set; }
        public string Comment { get; set; }
    }
}
