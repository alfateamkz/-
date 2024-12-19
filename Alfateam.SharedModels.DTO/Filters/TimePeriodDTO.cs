using Alfateam.SharedModels.Filters;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.DTO.Filters
{
    public class TimePeriodDTO : DTOModelAbs<TimePeriod>
    {
        public TimeOnly From { get; set; }
        public TimeOnly To { get; set; }
    }
}
