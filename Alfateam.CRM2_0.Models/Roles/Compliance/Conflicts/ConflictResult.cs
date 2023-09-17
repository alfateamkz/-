using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Conflicts
{
    /// <summary>
    /// Сущность результата урегулирования конфликта
    /// </summary>
    public class ConflictResult : AbsModel
    {
        public string Description { get; set; }
        public List<ConflictResultAction> Actions { get; set; } = new List<ConflictResultAction>();


        public bool IsLockedForEdit { get; set; }

	}
}
