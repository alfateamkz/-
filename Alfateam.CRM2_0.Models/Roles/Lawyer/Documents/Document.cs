using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Documents
{
    /// <summary>
    /// Модель документа
    /// </summary>
    public class Document : AbsModel
    {

        public User CreatedBy { get; set; }
		public int CreatedById { get; set; }



		public DocumentType Type { get; set; }
		public string Title { get; set; }
		public string? DocumentNumber { get; set; }
        public List<DocumentVersion> Versions { get; set; } = new List<DocumentVersion>();


        public SignedDocument? SignedDocument { get; set; }
		public int? SignedDocumentId { get; set; }





		[NotMapped]
		public bool IsUsedAnywhere
		{
			get
			{
				var isUsed = false;

				isUsed |= TrialHearingResultId != null;


				return isUsed;
			}
		}


		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int? TrialHearingResultId { get; set; }

		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int? TrialProcessResultId { get; set; }


		/// <summary>
		/// Автоматическое поле
		/// </summary>
		public int LawDepartmentId { get; set; }



    }
}
