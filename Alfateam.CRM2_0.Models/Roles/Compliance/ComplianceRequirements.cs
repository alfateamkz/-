using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance
{
    /// <summary>
    /// Сущность требований соответствия к какой-либо стороне
    /// </summary>
    public class ComplianceRequirements : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ComplianceRequirementsCategory Category { get; set; }

        public List<ComplianceCriteriaGroup> Groups { get; set; } = new List<ComplianceCriteriaGroup>();
    }
}
