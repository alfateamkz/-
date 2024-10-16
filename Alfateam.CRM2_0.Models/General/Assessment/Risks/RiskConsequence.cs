﻿using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Assessment.Risks
{
    /// <summary>
    /// Сущность последствия риска
    /// </summary>
    public class RiskConsequence : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public List<RiskConsequenceAction> ConsequenceActions { get; set; } = new List<RiskConsequenceAction>();

    }
}
