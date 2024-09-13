using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Taxes
{
    /// <summary>
    /// Грейд прогрессивной система налогообложения
    /// </summary>
    public class ProgressiveTaxSystemGrade : AbsModel
    {
        public double From { get; set; }
        public double? To { get; set; }


        public double Percent { get; set; }

    }
}
