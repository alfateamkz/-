using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Compliance;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Corruption.Participants
{
    /// <summary>
    /// Участник коррупционного инцидента с привязкой к CRM
    /// </summary>
    public class CRMBindedCorruptionCaseParticipant : CorruptionCaseParticipant
    {
        public User Person { get; set; }
        public int PersonId { get; set; }
    }
}
