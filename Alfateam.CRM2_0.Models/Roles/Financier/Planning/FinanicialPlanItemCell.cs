using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Planning
{
    /// <summary>
    /// Сущность ячейки статьи дохода/расхода финансового плана
    /// </summary>
    public class FinanicialPlanItemCell : AbsModel
    {
        public DateTime Date { get; set; }
        public double Sum { get; set; }
    }
}
