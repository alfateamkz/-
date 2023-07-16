using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Planning
{
    /// <summary>
    /// Сущность финансового плана
    /// </summary>
    public class FinanicialPlan : AbsModel
    {
        public List<FinanicialPlanItemsGroup> Groups { get; set; } = new List<FinanicialPlanItemsGroup>();
    }
}
