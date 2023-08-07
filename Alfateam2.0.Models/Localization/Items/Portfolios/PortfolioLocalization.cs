using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Portfolios
{
    public class PortfolioLocalization : LocalizableModel
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }


        /// <summary>
        /// Автоматическое свойство
        /// Указывает на главный объект (портфолио)
        /// </summary>
        public int PortfolioId { get; set; }
    }
}
