using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Trial
{
	/// <summary>
	/// Сущность конкретного здания суда
	/// </summary>
	public class Court : AbsModel
	{
		public string Title { get; set; }
		public Address Address { get; set; }


		public CourtStructure Structure { get; set; }
		public int StructureId { get; set; }

		public List<Judge> Judges { get; set; } = new List<Judge>();


		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int LawDepartmentId { get; set; }
	}
}
