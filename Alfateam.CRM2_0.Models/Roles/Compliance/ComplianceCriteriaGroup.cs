using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance
{
    /// <summary>
    /// Сущность группы критерий соответствия
    /// </summary>
    public class ComplianceCriteriaGroup : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public List<ComplianceCriteria> Criterias { get; set; } = new List<ComplianceCriteria>();   


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int ComplianceRequirementsId { get; set; }

	}
}
