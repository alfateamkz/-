﻿using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.General
{
    /// <summary>
    /// Сущность страны
    /// </summary>
    public class Country : AbsModel
    {
        public string Title { get; set; }
        public string Code { get; set; }
    }
}