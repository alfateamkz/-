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
    /// Сущность предложения по урегулированию конфликта
    /// </summary>
    public class ConflictResolutionProposal : AbsModel
    {
        /// <summary>
        /// Сторона конфликта, от которой поступило предложение
        /// </summary>
        public ConflictSide From { get; set; }

        /// <summary>
        /// Стороны конфликта, которым адресовано предложение
        /// </summary>
        public List<ConflictSide> To { get; set; } = new List<ConflictSide>();


        public string Title { get; set; }
        public string Description { get; set; }


        public List<ConflictResolutionProposalFeedback> Feedback { get; set; } = new List<ConflictResolutionProposalFeedback>();
        public ConflictResolutionProposalStatus Status { get; set; } = ConflictResolutionProposalStatus.Discussion;

    }
}
