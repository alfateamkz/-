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
    public class HeaderTexts : AbsModel
    {
        public string Main { get; set; }
        public string OurWorks { get; set; }
        public string Cost { get; set; }
        public string Services { get; set; }
        public string WorkForUs { get; set; }
        public string More { get; set; }
        public string WriteUs { get; set; }
    }

}
