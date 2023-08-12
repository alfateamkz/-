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
    /// Сущность услуги в аутстафф таблице
    /// </summary>
    public class OutstaffItem : AbsModel
    {
        public string Title { get; set; }
        public List<OutstaffItemGrade> Grades { get; set; } = new List<OutstaffItemGrade>();



        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<OutstaffItemLocalization> Localizations { get; set; } = new List<OutstaffItemLocalization>();

        
    }
}
