using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


    


        /// <summary>
        /// Автоматическое поле
        /// Указывает на главную сущность (язык)
        /// </summary>
        public int LanguageMainModelId { get; set; }
        public Language LanguageMainModel { get; set; }
    }
}
