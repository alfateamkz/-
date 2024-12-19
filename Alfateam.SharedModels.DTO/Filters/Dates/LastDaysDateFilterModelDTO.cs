using Alfateam.SharedModels.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.DTO.Filters.Dates
{
    public class LastDaysDateFilterModelDTO : DateFilterModelDTO
    {
        public int Days { get; set; }
    }
}
