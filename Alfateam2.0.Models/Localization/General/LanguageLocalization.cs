using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.General
{
    /// <summary>
    /// Сущность локализации языка
    /// </summary>
    public class LanguageLocalization : LocalizableModel
    {
        public string Title { get; set; }


        //TODO: задать связь 1 к 1

        /// <summary>
        /// Автоматическое поле
        /// Указывает на главную сущность (язык)
        /// </summary>
        public int LanguageMainModelId { get; set; }
    }
}
