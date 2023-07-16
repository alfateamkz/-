using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель штрафа по договорным или иным обязательствам
    /// </summary>
    public class Penalty : AbsModel
    {
        public PenaltyType Type { get; set; } = PenaltyType.PercentForTotal;
        public bool Value { get; set; }

    }
}
