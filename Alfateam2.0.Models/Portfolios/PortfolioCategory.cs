using Alfateam.Models.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Portfolios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Portfolios
{
    /// <summary>
    /// Сущность категории кейса
    /// </summary>
    public class PortfolioCategory : AvailabilityModel
    {
        public string Title { get; set; }

        [NotMapped]
        public string Slug => SlugHelper.GetLatynSlug(Title);


        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<PortfolioCategoryLocalization> Localizations { get; set; } = new List<PortfolioCategoryLocalization>();
    }
}
