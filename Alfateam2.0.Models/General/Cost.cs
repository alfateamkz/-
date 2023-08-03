﻿using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Сущность пары валюта - значение
    /// </summary>
    public class Cost : AbsModel
    {
        public Currency Currency { get; set; }
        public double Value { get; set; }
    }
}