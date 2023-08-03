using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Localization.Outstaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Outstaff
{
    /// <summary>
    /// Сущность колонки периода времени в аутстафф таблице
    /// У нас на сайте их три(до 3 месяцев, до 6 месяцев, от 6 месяцев)
    /// </summary>
    public class OutstaffColumn : AbsModel
    {
        public string Title { get; set; }
        public double Discount { get; set; }


        public List<OutstaffColumnLocalization> Localizations { get; set; } = new List<OutstaffColumnLocalization>();
    }
}
