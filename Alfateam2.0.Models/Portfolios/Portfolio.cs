using Alfateam.Models.Helpers;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
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
    /// Сущность кейса
    /// </summary>
    public class Portfolio : AvailabilityModel
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }

        [NotMapped]
        public string Slug => SlugHelper.GetLatynSlug(Title);

        public PortfolioCategory Category { get; set; }
        public int CategoryId { get; set; }


        public PortfolioIndustry Industry { get; set; }
        public int IndustryId { get; set; }



        public int Watches { get; set; }
        public List<Watch> WatchesList { get; set; } = new List<Watch>();
        public int Likes { get; set; }
        public List<RateVote> LikesList { get; set; } = new List<RateVote>();




        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<PortfolioLocalization> Localizations { get; set; } = new List<PortfolioLocalization>();


        public override bool IsValid()
        {
            bool isValid = base.IsValid();

            foreach(var localization in Localizations)
            {
                isValid &= localization.IsValid();
            }


            return isValid;
        }
    }
}
