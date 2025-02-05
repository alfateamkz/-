using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Loyalty.Programs.Types.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Loyalty.Programs.Types
{
    public class ProgressiveLoyaltyProgram : LoyaltyProgram
    {
        public List<ProgressiveLoyaltyProgramGrade> Grades { get; set; } = new List<ProgressiveLoyaltyProgramGrade>();
    }
}
