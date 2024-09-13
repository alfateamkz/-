using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Portfolio
{
    public class PortfolioListPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Портфолио";
        public string Header { get; set; } = "ПОРТФОЛИО";

        public string LastBreadcrumpChrono { get; set; } = "Хронология";
        public string HeaderChrono { get; set; } = "ХРОНОЛОГИЯ";



        public string Directions { get; set; } = "Направления";
        public string Industries { get; set; } = "Индустрии";
        public string SearchTitle { get; set; } = "Поиск";
        public string SearchPlaceholder { get; set; } = "Поиск работ";
        public string SearchBtn { get; set; } = "Найти";
    }
}
