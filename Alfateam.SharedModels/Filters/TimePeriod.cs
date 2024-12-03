using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.Filters
{
    public class TimePeriod : AbsModel
    {
        public TimeOnly From { get; set; }
        public TimeOnly To { get; set; }
    }
}
