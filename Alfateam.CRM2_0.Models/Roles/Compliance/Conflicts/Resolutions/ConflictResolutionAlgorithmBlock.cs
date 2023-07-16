using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Conflicts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts.Resolutions
{
    /// <summary>
    /// Сущность блока алгоритма урегулирования конфликта
    /// </summary>
    public class ConflictResolutionAlgorithmBlock : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public ConflictResolutionAlgorithmBlockType Type { get; set; } = ConflictResolutionAlgorithmBlockType.Information;

        /// <summary>
        /// Ветвления алгоритма
        /// </summary>
        public List<ConflictResolutionAlgorithmBlock> Nodes { get; set; } = new List<ConflictResolutionAlgorithmBlock>();
    }
}
