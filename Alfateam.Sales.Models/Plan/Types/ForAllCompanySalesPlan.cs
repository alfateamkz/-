using Alfateam.Sales.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Plan.Types
{
    public class ForAllCompanySalesPlan : SalesPlan
    {
        public double Value { get; set; }

        public override bool CompliesWithOtherPlan(SalesPlan other)
        {
            if (!base.CompliesWithOtherPlan(other))
            {
                return false;
            }
            return Value > 0;
        }
    }
}
