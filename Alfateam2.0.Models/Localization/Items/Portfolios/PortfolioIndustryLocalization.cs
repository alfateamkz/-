using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Portfolios
{
    public class PortfolioIndustryLocalization : LocalizableModel
    {
        public string Title { get; set; }


        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(Title)}-{PortfolioIndustryId}";


        /// <summary>
        /// Автоматическое поле
        /// Указывает на главный объект (индустрия)
        /// </summary>
        public int PortfolioIndustryId { get; set; }
    }
}
