using Alfateam.SharedModels.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.DTO.Filters.ByValue
{
    public class RangeByValueFilterDTO : ByValueFilterDTO
    {
        public double From { get; set; }
        public double To { get; set; }
    }
}
