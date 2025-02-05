using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Loyalty.Programs.Types
{
    public class SimpleLoyaltyProgram : LoyaltyProgram
    {
        public double Percent { get; set; }
    }
}
