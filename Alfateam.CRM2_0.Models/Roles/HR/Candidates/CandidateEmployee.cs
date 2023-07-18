using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.TestTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR.Candidates
{
    /// <summary>
    /// Модель кандидата-работника
    /// </summary>
    public class CandidateEmployee : Candidate
    {
        public string? CVPath { get; set; }
    }
}
