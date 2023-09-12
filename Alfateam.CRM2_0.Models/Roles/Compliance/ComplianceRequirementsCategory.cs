using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance
{
    /// <summary>
    /// Сущность категории требований соответствия 
    /// По умолчанию у нас 3 категории: клиенты, сотрудники и контрагенты
    /// </summary>
    public class ComplianceRequirementsCategory : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }




		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int ComplianceDepartmentId { get; set; }
	}
}
