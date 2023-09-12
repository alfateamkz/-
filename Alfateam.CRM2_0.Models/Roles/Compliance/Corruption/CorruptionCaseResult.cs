using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Corruption
{
    /// <summary>
    /// Результат коррупционного инцидента
    /// </summary>
    public class CorruptionCaseResult : AbsModel
    {
        /// <summary>
        /// Ответственный за решение
        /// </summary>
        public User DecisionMaker { get; set; }
        public int DecisionMakerId { get; set; }

        public string Description { get; set; }

    }
}
