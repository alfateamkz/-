using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Lawyer.Trial;
using Alfateam.CRM2_0.Models.Roles.Lawyer.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Trial
{
    /// <summary>
    /// Сущность результата судебного заседания
    /// </summary>
    public class TrialHearingResult : AbsModel
    {
        public TrialHearingResultType Type { get; set; } = TrialHearingResultType.LawsuitApproved;
        public string Description { get; set; }
		public bool IsLockedForChanges { get; set; }

		public List<Document> Documents { get; set; } = new List<Document>();

       
    }
}
