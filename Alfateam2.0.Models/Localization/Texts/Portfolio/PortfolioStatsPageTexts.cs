using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Portfolio
{
    public class PortfolioStatsPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Статистика";
        public string Header { get; set; } = "СТАТИСТИКА";


        public string FilterYearTitle { get; set; } = "Год";
        public string FilterYearPlaceholder { get; set; } = "2017";

        public string FilterMonthTitle { get; set; } = "Месяц";
        public string FilterMonthPlaceholder { get; set; } = "март";

        public string FilterBtn { get; set; } = "Готово";
    }
}
