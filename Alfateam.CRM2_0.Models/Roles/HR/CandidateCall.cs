using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.HR;
using Alfateam.CRM2_0.Models.Enums.Roles.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.HR
{
    /// <summary>
    /// Модель созвона с кандидатом
    /// </summary>
    public class CandidateCall : AbsModel
    {
        public Candidate CallWith { get; set; }

        public CandidateCallStatus Status { get; set; } = CandidateCallStatus.Planned;
        public DateTime InitialPlannedTime { get; set; }
        public DateTime? PostponedPlannedTime { get; set; }

        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }

        public string? CallRecordPath { get; set; }


        /// <summary>
        /// История переноса созвонов
        /// </summary>
        public List<CandidateCallRescheduling> Reschedulings { get; set; } = new List<CandidateCallRescheduling>();
    }
}
