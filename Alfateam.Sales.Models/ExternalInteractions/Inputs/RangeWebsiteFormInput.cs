using Alfateam.Sales.Models.Abstractions.ExtInterations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions.Inputs
{
    public class RangeWebsiteFormInput : WebsiteFormInput
    {
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double Step { get; set; }
    }
}
