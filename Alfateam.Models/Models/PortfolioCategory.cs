using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class PortfolioCategory
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<TranslationItem> Captions { get; set; } = new List<TranslationItem>();

        public override string ToString()
        {
            return Captions.FirstOrDefault(o => o.Language.Code == "RU").Text;
        }
    }
}
