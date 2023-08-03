using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Portfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Portfolios
{
    /// <summary>
    /// Сущность кейса
    /// </summary>
    public class Portfolio : AbsModel
    {
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public Content Content { get; set; }

        public PortfolioCategory Category { get; set; }
        public PortfolioIndustry Industry { get; set; }
        


        public int Watches { get; set; }
        public List<Watch> WatchesList { get; set; } = new List<Watch>();
        public int Likes { get; set; }
        public List<RateVote> LikesList { get; set; } = new List<RateVote>();



        public List<PortfolioLocalization> Localizations { get; set; } = new List<PortfolioLocalization>();
    }
}
