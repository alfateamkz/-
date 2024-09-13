using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Portfolio
{
    public class PortfolioItemPageTexts : LocalizableModel
    {
        public string LastBreadcrump { get; set; } = "Проект";


        public string ProjectPeculiarities { get; set; } = "ОСОБЕННОСТИ ПРОЕКТА";
        public string ProjectStack { get; set; } = "СТЕК ПРОЕКТА";
    }
}
