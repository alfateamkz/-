using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Trial
{
    /// <summary>
    /// Результат судебного процесса
    /// </summary>
    public class TrialProcessResult : AbsModel
    {
        public string Description { get; set; }
        public List<Document> Documents { get; set; } = new List<Document>();


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int LitigationId { get; set; }
    }
}
