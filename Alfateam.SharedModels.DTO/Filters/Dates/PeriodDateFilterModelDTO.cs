using Alfateam.SharedModels.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.DTO.Filters.Dates
{
    public class PeriodDateFilterModelDTO : DateFilterModelDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
