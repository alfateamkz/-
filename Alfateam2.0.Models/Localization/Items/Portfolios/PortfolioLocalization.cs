using Alfateam.Core.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Portfolios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        [NotMapped]
        public string Slug => $"{SlugHelper.GetLatynSlug(Title)}-{PortfolioId}";


        /// <summary>
        /// Автоматическое свойство
        /// Указывает на главный объект (портфолио)
        /// </summary>
        public int PortfolioId { get; set; }
    }
}
