using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Accountance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Planning
{
    /// <summary>
    /// Сущность статьи дохода/расхода финансового плана
    /// </summary>
    public class FinanicialPlanItem : AbsModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<FinanicialPlanItemCell> Cells { get; set; } = new List<FinanicialPlanItemCell>();
        
     
    }
}
