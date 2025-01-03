﻿using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Shop.Modifiers
{
    public class ProductModifierLocalization : LocalizableModel
    {
        public string Title { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// Указывает на главную сущность (модификатор)
        /// </summary>
        public int ProductModifierId { get; set; }  
    }
}
