using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.General
{
    /// <summary>
    /// Сущность локализации страны
    /// </summary>
    public class CountryLocalization : LocalizableModel
    {
        public string Title { get; set; }

        /// <summary>
        /// Автоматическое поле
        /// Указывает на главную сущность (страну)
        /// </summary>
        public int CountryId { get; set; }
    }
}
