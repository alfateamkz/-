using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.TestTasks
{
    /// <summary>
    /// Модель решения тестового задания кандидатом
    /// </summary>
    public class CandidateTestTaskAnswer : AbsModel
    {  
        public string Answer { get; set; }
        public List<CandidateTestTaskAnswerAttachment> Attachments { get; set; } = new List<CandidateTestTaskAnswerAttachment>();
    }
}
