using Alfateam.Database.Abstraction;
using Alfateam.Database.Models.Localizations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class PortfolioCategory : BaseModel {




        public string? Caption { get; set; }
        public List<PortfolioCategoryLocalization> Localizations { get; set; } = new List<PortfolioCategoryLocalization>();




        public string GetLocalizedCaption(int langId)
        {
            string str = Localizations.FirstOrDefault(o => o.LanguageId == langId)?.Caption;
            if (string.IsNullOrEmpty(str))
            {
                str = Caption;
            }
            return str;
        }
        public override string ToString()
        {
            return Caption;
        }
    }
}
