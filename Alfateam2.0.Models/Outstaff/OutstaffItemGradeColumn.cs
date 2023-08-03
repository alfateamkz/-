﻿using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Outstaff
{
    /// <summary>
    /// Модель цены по определенной колонке
    /// </summary>
    public class OutstaffItemGradeColumn : AbsModel
    {
        public OutstaffColumn Column { get; set; }
        public PricingMatrix CostPerHour { get; set; }
    }
}
