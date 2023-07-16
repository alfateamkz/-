using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts
{
    /// <summary>
    /// Сущность ответа на предложение по урегулированию конфликта
    /// </summary>
    public class ConflictResolutionProposalFeedback : AbsModel
    {
        public ConflictSide Side { get; set; }
        public ConflictResolutionProposalFeedbackStatus Status { get; set; } = ConflictResolutionProposalFeedbackStatus.Approved;

        public string? Comment { get; set; }
    }
}
