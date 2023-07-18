using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Taxes
{
    /// <summary>
    /// Обычная фиксированния система налогообложения 
    /// Например: фиксированный налог бывает обычно у ИП на патентной системе налогообложения в РФ
    /// </summary>
    public class SimpleFixedTaxSystem : TaxSystem
    {      
        public double Sum { get; set; }

        /// <summary>
        /// Лимит, до которого дейтствует налоговый режим. 
        /// Например, в России по УСН доход не должен составлять более 150 млн. 
        /// </summary>
        public double? Limit { get; set; }
   
    }
}
