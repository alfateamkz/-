using Alfateam.Sales.Models.Abstractions.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Tasks.AsCompleted
{
    public class WithAmountMarkedAsCompleted : MarkedAsCompleted
    {
        public double Amount { get; set; }
    }
}
