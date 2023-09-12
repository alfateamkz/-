using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Fraud
{
    /// <summary>
    /// Сущность описания мошеннического способа
    /// </summary>
    public class FraudDescription : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public FraudCategory Category { get; set; }
        public int CategoryId { get; set; } 

		public List<FraudPreventionMethod> PreventionMethods { get; set; } = new List<FraudPreventionMethod>();



		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int ComplianceDepartmentId { get; set; }

	}
}
