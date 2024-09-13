using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Common
{
    /// <summary>
    /// Сущность текстов хедера
    /// </summary>
    public class HeaderTexts : LocalizableModel
    {
        public string Main { get; set; } = "ГЛАВНАЯ";
        public string OurWorks { get; set; } = "ПОРТФОЛИО";
        public string Cost { get; set; } = "АУТСТАФФ";
        public string Services { get; set; } = "УСЛУГИ";
        public string WorkForUs { get; set; } = "ВАКАНСИИ";
        public string More { get; set; } = "ЕЩЕ";
        public string WriteUs { get; set; } = "НАПИСАТЬ НАМ";
    }

}
