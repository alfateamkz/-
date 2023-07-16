using Alfateam.Database.Abstraction;
using Alfateam.Database.Models.Localizations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Portfolios
{
    public class Portfolio : BaseModel {




        public PortfolioCategory Category { get; set; }
        public int CategoryId { get; set; }

        public string URL { get; set; } = "";

        public bool IsHidden { get; set; }


        public List<PortfolioImage> Images { get; set; } = new List<PortfolioImage>();



        public string? Caption { get; set; }
        public string? Description { get; set; }
        public List<PortfolioLocalization> Localizations { get; set; } = new List<PortfolioLocalization>();



        public string GetLocalizedCaption(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.Caption;
            if (string.IsNullOrEmpty(str))
            {
                str = Caption;
            }
            return str;
        }
        public string GetLocalizedDescription(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.Description;
            if (string.IsNullOrEmpty(str))
            {
                str = Description;
            }
            return str;
        }
    }
}
