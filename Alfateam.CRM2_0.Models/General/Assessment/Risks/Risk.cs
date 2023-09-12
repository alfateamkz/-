using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Assessment.Risks
{
    /// <summary>
    /// Сущность риска
    /// </summary>
    public class Risk : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Оценка риска до проведения мероприятий по управлению риском
        /// </summary>
        public RiskAssessment AssessmentBefore { get; set; }

        /// <summary>
        /// Мероприятия по управлению риском
        /// </summary>
        public List<RiskManagementAction> ManagementActions { get; set; } = new List<RiskManagementAction>();

        /// <summary>
        /// Оценка риска после проведения мероприятий по управлению риском
        /// </summary>
        public RiskAssessment AssessmentAfter { get; set; }




		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int? ComplianceDepartmentId { get; set; }
	}
}
