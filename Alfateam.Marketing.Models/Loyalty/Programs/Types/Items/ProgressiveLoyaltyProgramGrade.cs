using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Loyalty.Programs.Types.Items
{
    public class ProgressiveLoyaltyProgramGrade : AbsModel
    {
        public double Threshold { get; set; }
        public double Percent { get; set; }
    }
}
