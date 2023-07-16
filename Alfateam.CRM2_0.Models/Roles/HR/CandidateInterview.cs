using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Roles.HR.TestTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR
{
    /// <summary>
    /// Модель собеседования с кандидатом
    /// </summary>
    public class CandidateInterview : AbsModel
    {
        public List<CandidateTestTask> TestTasks { get; set; } = new List<CandidateTestTask>();
        public CandidateCall Call { get; set; }

        public CandidateInterviewDecision? Decision { get; set; }
    }
}
