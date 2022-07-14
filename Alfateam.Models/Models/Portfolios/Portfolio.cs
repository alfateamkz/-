using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Portfolios
{
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        

        public PortfolioCategory Category { get; set; }
        public int CategoryId { get; set; }


        public List<PortfolioImage> Images { get; set; } = new List<PortfolioImage>();


        public List<TranslationItem> Captions { get; set; } = new List<TranslationItem>();
        public List<TranslationItem> Descriptions { get; set; } = new List<TranslationItem>();
    }
}
