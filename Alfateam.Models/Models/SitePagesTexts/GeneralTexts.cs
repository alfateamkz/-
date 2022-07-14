using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.SitePagesTexts
{
    public class GeneralTexts
    {
        [Key]
        public int Id { get; set; }

        #region Header
        public List<TranslationItem> Main { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> ServicesPrice { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> OurWorks { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Partners { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> News { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Team { get; set; } = new List<TranslationItem>();
        #endregion


        public List<TranslationItem> PublishedAt { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Close { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Categories { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> AddedAt { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Watches { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> AllPortfolios { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> NewPortfolioLabel { get; set; } = new List<TranslationItem>();

        #region Footer
        public List<TranslationItem> Navigation { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Contacts { get; set; } = new List<TranslationItem>();



        public List<TranslationItem> SocialNetworks { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> AllRightsReserved { get; set; } = new List<TranslationItem>();

        #endregion

    }
}
