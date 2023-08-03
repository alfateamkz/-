﻿using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts
{
    /// <summary>
    /// Сущность перевода политики конфедициальности
    /// </summary>
    public class PrivacyPolicy : LocalizableModel
    {
        public string LastBreadcrump { get; set; }
        public Content Content { get; set; }
    }
}
