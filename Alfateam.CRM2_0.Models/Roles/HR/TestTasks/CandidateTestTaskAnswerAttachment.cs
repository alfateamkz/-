using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.TestTasks
{
    /// <summary>
    /// Модель вложения решения тестового задания кандидатом
    /// </summary>
    public class CandidateTestTaskAnswerAttachment : AbsModel
    {
        public string Filepath { get; set; }
    }
}
