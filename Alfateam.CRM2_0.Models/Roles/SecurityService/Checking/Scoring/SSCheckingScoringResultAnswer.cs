﻿using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.SecurityService.Checking.Scoring
{
    /// <summary>
    /// Модель ответа на вопрос результата скоринга
    /// </summary>
    public class SSCheckingScoringResultAnswer : AbsModel
    {
        public string OptionText { get; set; }
        public double Score { get; set; }

    }
}
