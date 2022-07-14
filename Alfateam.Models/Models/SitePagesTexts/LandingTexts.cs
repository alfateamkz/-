using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.SitePagesTexts
{
    public class LandingTexts
    {
        [Key]
        public int Id { get; set; }

        public List<TranslationItem> StartBusiness { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> StartBusinessDescriptions { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> OrderNow { get; set; } = new List<TranslationItem>();



        public List<TranslationItem> WeAcceptPayments { get; set; } = new List<TranslationItem>();

        public List<TranslationItem> OurPortfolios { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> OurLastPortfolios { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> MorePortfolios { get; set; } = new List<TranslationItem>();


        #region Новости
        public List<TranslationItem> News { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> DiscoverNews { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> NewsDetails { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> NewsMore { get; set; } = new List<TranslationItem>();

        #endregion

        #region Форма отправки заявки

        public List<TranslationItem> Order { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> MakeOrder { get; set; } = new List<TranslationItem>();


        public List<TranslationItem> YourName { get; set; } = new List<TranslationItem>();

        public List<TranslationItem> CompanyName { get; set; } = new List<TranslationItem>();


        public List<TranslationItem> DescribeJob { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> DescribeJobPlaceholder { get; set; } = new List<TranslationItem>();

        public List<TranslationItem> YourBudget { get; set; } = new List<TranslationItem>();


        public List<TranslationItem> Contacts { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> ContactsPlaceholder { get; set; } = new List<TranslationItem>();


        public List<TranslationItem> Send { get; set; } = new List<TranslationItem>();


        public List<TranslationItem> OrderCompleted { get; set; } = new List<TranslationItem>();

        #endregion
    }
}
