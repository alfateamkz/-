using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Taxes
{
    /// <summary>
    /// Обычная процентная система налогообложения 
    /// </summary>
    public class SimplePercentTaxSystem : TaxSystem
    {      
        public double Percent { get; set; }

        /// <summary>
        /// Лимит, до которого действует налоговый режим. 
        /// Например, в России по УСН доход не должен составлять более 150 млн. 
        /// </summary>
        public double? Limit { get; set; }
   
    }
}
