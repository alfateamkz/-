using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using Alfateam.CRM2_0.Models.Roles.HR.TestTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR
{
    /// <summary>
    /// Модель кандидата на работу
    /// </summary>
    public class Candidate : User
    {
        public string? CVPath { get; set; }
        public CandidateStatus Status { get; set; } = CandidateStatus.Waiting;

        public List<CandidateInterview> Interviews { get; set; } = new List<CandidateInterview>();


        //TODO: проработать кейс кандидата-студии

    }
}
