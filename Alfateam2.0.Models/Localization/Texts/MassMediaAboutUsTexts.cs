using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts
{
    /// <summary>
    /// Сущность перевода текста страницы СМИ о нас
    /// </summary>
    public class MassMediaAboutUsTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "СМИ о нас";
        public string Header { get; set; } = "СМИ о нас";




        public string AnotherNews { get; set; } = "ДРУГИЕ НОВОСТИ";
    }
}
