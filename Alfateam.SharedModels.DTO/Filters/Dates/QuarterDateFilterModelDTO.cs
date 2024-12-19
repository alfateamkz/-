﻿using Alfateam.SharedModels.DTO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.SharedModels.DTO.Filters.Dates
{
    public class QuarterDateFilterModelDTO : DateFilterModelDTO
    {
        public int Year { get; set; }
        public int Quarter { get; set; }

    }
}
