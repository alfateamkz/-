using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Assessment.Risks
{
    /// <summary>
    /// Группа рисков
    /// </summary>
    public class RisksGroup : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<RisksGroup> Subgroups { get; set; } = new List<RisksGroup>();
        public List<Risk> Risks { get; set; } = new List<Risk>();
    }
}
