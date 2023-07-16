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
    /// Сущность конфликта внутри компании
    /// </summary>
    public class Conflict : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }



        public ConflictStatus Status { get; set; } = ConflictStatus.Opened;
        public List<ConflictSide> Sides { get; set; } = new List<ConflictSide>();



        public List<ConflictResolutionProposal> Proposals { get; set; } = new List<ConflictResolutionProposal>();
        public ConflictResult? Result { get; set; }
    }
}
