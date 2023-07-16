using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Corruption
{
    /// <summary>
    /// Сущность коррупционного инцидента
    /// </summary>
    public class CorruptionCase : AbsModel
    {
        public CorruptionCaseInitDetails InitDetails { get; set; }

        public List<CorruptionCaseSide> Sides { get; set; } = new List<CorruptionCaseSide>();


        public List<CorruptionCaseAction> Actions { get; set; } = new List<CorruptionCaseAction>();
        public CorruptionCaseResult? Result { get; set; }
    }
}
