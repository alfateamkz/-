using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Portfolios
{
    public class PortfolioIndustryLocalization : LocalizableModel
    {
        public string Title { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// Указывает на главный объект (индустрия)
        /// </summary>
        public int PortfolioIndustryId { get; set; }
    }
}
