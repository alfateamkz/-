﻿using Alfateam.Marketing.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Referral
{
    public class SimpleReferralProgram : ReferralProgram
    {
        public double Percent { get; set; }
    }
}
