using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Corruption
{
    /// <summary>
    /// Участник коррупционного инцидента
    /// </summary>
    public class CorruptionCaseParticipant : AbsModel
    {
        public User Person { get; set; }
        public string Comment { get; set; }

    }
}
