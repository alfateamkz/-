﻿using Alfateam.EDM.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models
{
    public class CounterpartyGroup : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public int EDMSubjectId { get; set; }
    }
}
