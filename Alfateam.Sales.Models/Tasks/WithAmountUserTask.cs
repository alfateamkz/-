using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Tasks
{
    public class WithAmountUserTask : UserTask
    {
        public double Amount { get; set; }
        public string MeasureUnit { get; set; } = "шт.";

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }




        public double CompletedAmount { get; set; }
    }
}
