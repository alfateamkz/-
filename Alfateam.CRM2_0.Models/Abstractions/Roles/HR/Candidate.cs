using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Roles.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.HR
{
    /// <summary>
    /// Базовая модель кандидата
    /// От данного класса наследуются CandidateEmployee (кандидат-работник) 
    /// и CandidateCounterparty (кандидат-контрагент)
    /// </summary>
    public abstract class Candidate : User
    {
        public CandidateStatus Status { get; set; } = CandidateStatus.Waiting;
        public List<CandidateInterview> Interviews { get; set; } = new List<CandidateInterview>();
    }
}
