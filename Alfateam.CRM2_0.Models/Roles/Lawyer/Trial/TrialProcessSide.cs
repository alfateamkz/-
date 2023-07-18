using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Trial
{
    /// <summary>
    /// Сторона судебного процесса
    /// </summary>
    public class TrialProcessSide : AbsModel
    {
        public TrialProcessSideRole Role { get; set; } = TrialProcessSideRole.Plaintiff;
        public List<TrialProcessParticipant> Participants { get; set; } = new List<TrialProcessParticipant>();

    }
}
