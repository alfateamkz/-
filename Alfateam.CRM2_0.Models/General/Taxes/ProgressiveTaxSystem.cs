using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Taxes
{
    /// <summary>
    /// Прогрессивная система налогообложения
    /// </summary>
    public class ProgressiveTaxSystem : TaxSystem
    {
        public List<ProgressiveTaxSystemGrade> Grades { get; set; } = new List<ProgressiveTaxSystemGrade>();
    }
}
