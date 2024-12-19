using Alfateam.SharedModels.DTO.Abstractions;
using Alfateam.SharedModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.DTO.Filters.ByValue
{
    public class ConditionalByValueFilterDTO : ByValueFilterDTO
    {
        public ConditionalByValueFilterType Type { get; set; }
        public double Value { get; set; }
    }
}
