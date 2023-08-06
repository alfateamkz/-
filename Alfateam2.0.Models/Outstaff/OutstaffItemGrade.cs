using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Outstaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Outstaff
{
    /// <summary>
    /// Вариация услуги в аутстафф таблице
    /// На сайте выглядит так(Middle, Senior, Architect)
    /// </summary>
    public class OutstaffItemGrade : AbsModel
    {
        public string Title { get; set; }
        public List<OutstaffItemGradeColumn> Prices { get; set; } = new List<OutstaffItemGradeColumn>();



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<OutstaffItemGradeLocalization> Localizations { get; set; } = new List<OutstaffItemGradeLocalization>();
    }
}
