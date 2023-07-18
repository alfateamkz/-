using Alfateam.CRM2_0.Models.Abstractions.Roles.Lawyer;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Trial.Participants
{
    /// <summary>
    /// Cущность участника судебного процесса c привязкой к пользователю CRM
    /// </summary>
    public class CRMTrialProcessParticipant : TrialProcessParticipant
    {
        public User User { get; set; }
    }
}
